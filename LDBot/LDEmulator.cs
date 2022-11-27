using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Text;

namespace LDBot
{
    public class LDEmulator : IEquatable<LDEmulator>
    {
        private int _index;
        private string _name;
        private IntPtr _topHandle;
        private IntPtr _bindHandle;
        private bool _isRunning;
        private bool _isUseProxy;
        private string _proxy;
        private int _pID;
        private int _vBoxPID;
        public BotAction botAction;
        private readonly string _scriptFolder;
        private string _deviceID;

        #region Constructor

        public LDEmulator() { }

        public LDEmulator(int index, string name, IntPtr topHandle, IntPtr bindHandle, bool isRunning, int pID, int vBoxPID)
        {
            this._index = index;
            this._name = name;
            this._topHandle = topHandle;
            this._bindHandle = bindHandle;
            this._isRunning = isRunning;
            this._pID = pID;
            this._vBoxPID = vBoxPID;
            this.botAction = new BotAction(this);
            this._scriptFolder = ConfigurationManager.AppSettings["LDPath"] + "\\Scripts\\" + this._name;
            this._isUseProxy = false;
            this._proxy = "";
            if (!Directory.Exists(this._scriptFolder))
            {
                Directory.CreateDirectory(this._scriptFolder);
            }
        }
        #endregion

        #region Get_Set
        public string Proxy
        {
            get { return _proxy; }
            set { _proxy = value; }
        }
        public bool isUseProxy
        {
            get { return _isUseProxy; }
            set { _isUseProxy = value; }

        }
        public string ScriptFolder
        {
            get { return _scriptFolder; }
        }
        public string DeviceID
        {
            get { return _deviceID; }
            set { _deviceID = value; }
        }
        public int VboxPID
        {
            get { return _vBoxPID; }
            set { _vBoxPID = value; }
        }

        public int pID
        {
            get { return _pID; }
            set { _pID = value; }
        }

        public bool isRunning
        {
            get { return _isRunning; }
            set { _isRunning = value; }
        }

        public IntPtr BindHandle
        {
            get { return _bindHandle; }
            set { _bindHandle = value; }
        }

        public IntPtr TopHandle
        {
            get { return _topHandle; }
            set { _topHandle = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }
        #endregion
        public bool Equals(LDEmulator other)
        {
            return other.Index == this.Index;
        }

        public void GenerateCode()
        {
            try
            {
                Dictionary<string, CompilerErrorCollection> e = new Dictionary<string, CompilerErrorCollection>();
                string[] files = Directory.GetFiles(this._scriptFolder, "*.cs");
                List<ScriptFileNameEntity> scriptFileList = new List<ScriptFileNameEntity>();
                if (files.Length != 0)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    int num = 8;
                    for (int index = 0; index < files.Length; ++index)
                    {
                        FileInfo fileInfo = new FileInfo(files[index]);
                        string str = System.IO.File.ReadAllText(files[index]);
                        int length = str.Split('\n').Length;
                        scriptFileList.Add(new ScriptFileNameEntity()
                        {
                            BeginLine = num,
                            EndLine = num + length,
                            FileName = fileInfo.Name
                        });
                        num += length;
                        stringBuilder.AppendLine(str);
                    }
                    this.GenerateCode(e, stringBuilder.ToString().Replace("System.Reflection.", "").Replace("System.CodeDom.Compiler", ""), scriptFileList);
                }
                else
                    Helper.raiseOnUpdateLDStatus(this._index, "Scripts not found");
            }
            catch(Exception e)
            {
                Helper.raiseOnErrorMessage(e);
            }
        }

        private void GenerateCode(Dictionary<string, CompilerErrorCollection> e, string ItemName, List<ScriptFileNameEntity> isMainPlayer)
        {
            CSharpCodeProvider csharpCodeProvider = new CSharpCodeProvider();
            CompilerParameters options = new CompilerParameters() { GenerateInMemory = true, GenerateExecutable = false };
            options.ReferencedAssemblies.Add("system.dll");
            options.ReferencedAssemblies.Add("system.core.dll");
            options.ReferencedAssemblies.Add("system.data.dll");
            options.ReferencedAssemblies.Add("System.Threading.Tasks.dll");
            options.ReferencedAssemblies.Add("System.Windows.Forms.dll");
            options.ReferencedAssemblies.Add("System.Drawing.dll");
            options.ReferencedAssemblies.Add("Emgu.CV.UI.dll");
            options.ReferencedAssemblies.Add("Emgu.CV.World.dll");
            options.ReferencedAssemblies.Add("ZedGraph.dll");
            options.ReferencedAssemblies.Add("KAutoHelper.dll");
            options.ReferencedAssemblies.Add("xNet.dll");
            options.ReferencedAssemblies.Add("Newtonsoft.Json.dll");
            options.ReferencedAssemblies.Add("MailKit.dll");
            options.ReferencedAssemblies.Add("MimeKit.dll");
            options.ReferencedAssemblies.Add("LDBot.exe");
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("using System;");
            stringBuilder.AppendLine("using System.Linq;");
            stringBuilder.AppendLine("using System.Collections.Generic;");
            stringBuilder.AppendLine("using System.Windows.Forms;");
            stringBuilder.AppendLine("using System.Text;");
            stringBuilder.AppendLine("using System.Text.RegularExpressions;");
            stringBuilder.AppendLine("using System.Drawing;");
            stringBuilder.AppendLine("using System.Drawing.Imaging;");
            stringBuilder.AppendLine("using System.Threading;");
            stringBuilder.AppendLine("using System.Threading.Tasks;");
            stringBuilder.AppendLine("using System.IO;");
            stringBuilder.AppendLine("using System.Runtime.InteropServices;");
            stringBuilder.AppendLine("using Newtonsoft.Json;");
            stringBuilder.AppendLine("using KAutoHelper;");
            stringBuilder.AppendLine("using xNet;");
            stringBuilder.AppendLine("using MailKit;");
            stringBuilder.AppendLine("using MimeKit;");
            stringBuilder.AppendLine("namespace LDBot {");
            stringBuilder.AppendLine("class AutoScriptExternalClass:BotAction {");
            stringBuilder.AppendLine("public AutoScriptExternalClass(LDEmulator _ld) : base(_ld) { }");
            stringBuilder.AppendLine(ItemName);
            stringBuilder.AppendLine("}");
            stringBuilder.AppendLine("}");
            stringBuilder.ToString();
            CompilerResults results = csharpCodeProvider.CompileAssemblyFromSource(options, stringBuilder.ToString());
            if (results.Errors.Count == 0 && results.CompiledAssembly != (Assembly)null)
            {
                Type type = results.CompiledAssembly.GetType("LDBot.AutoScriptExternalClass");
                try
                {
                    if (type != (System.Type)null)
                    {
                        botAction = (BotAction)Activator.CreateInstance(type, this);
                        botAction.Init();
                    }
                }
                catch (Exception ex)
                {
                    Helper.raiseOnErrorMessage(ex);
                }
            }
            else
            {
                Helper.raiseOnErrorMessage(new Exception("Script has error"));
                for (int i = 0; i < results.Errors.Count; i++)
                {
                    ScriptFileNameEntity scriptFileNameEntity = isMainPlayer.Find((Predicate<ScriptFileNameEntity>)(obj0 =>
                    {
                        if (results.Errors[i].Line >= obj0.BeginLine)
                            return results.Errors[i].Line <= obj0.EndLine;
                        return false;
                    }));
                    if (scriptFileNameEntity != null)
                    {
                        results.Errors[i].FileName = scriptFileNameEntity.FileName;
                        results.Errors[i].Line -= scriptFileNameEntity.BeginLine;
                    }
                }
                e.Add("Global", results.Errors);
                new FormError(e).Show();
            }
        }
    }
}
