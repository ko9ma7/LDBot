<!-- TABLE OF CONTENTS -->
<details>
  <summary>Mục Lục</summary>
  <ul>
    <li><a href="#variables">Variables</a></li>
    <li><a href="#virtualfunc">Virtual Functions</a></li>
    <li><a href="#botfunc">Script Functions</a></li>
    <li><a href="#adbhelper">ADBHelper Functions</a></li>
    <li><a href="#usedlibrary">Used Libraries</a></li>
  </ul>
</details>

<!-- Variables -->
## variables
```cs
bool isRunning //kiểm tra trạng thái script đang chạy hay dừng, dùng để ngắt script | khởi tạo false
_ld: {
	Index: int,
	Name: string,
	TopHandle: IntPtr,
	BindHandle: IntPtr,
	isRunning: bool,
	pID: int,
	VboxPID: int
	botAction: BotAction,
	ScriptFolder: string,
	DeviceID: string
}
```
#region Hàm virtual
	void Init() //Chạy ngay khi chọn Load Script
	void Start() //Chạy khi chọn Start Script
	void Stop() // set isRunning = false
#endregion
#region Hàm tiện ích
	void setStatus(string stt) //Cập nhật trạng thái vào list view
	bool findImage(string imgPath, [double similarPercent = 0.9, int startCropX = 0, int startCropY = 0, int cropWidth = 0, int cropHeight = 0]) //Tìm kiếm hình ảnh
	bool findAndClick(string imgPath, [double similarPercent = 0.9, int xPlus = 0, int yPlus = 0, int startCropX = 0, int startCropY = 0, int cropWidth = 0, int cropHeight = 0]) //Tìm kiếm và click theo hình ảnh.
	List<string> getInstalledPackages() //lấy danh sách app được cài đặt dưới dạng package name. Mỗi Package Name có dạng: com.cyanogenmod.filemanager
	void runApp(string packageName) //run app theo package name
	void killApp(string packageName) //kill app theo package name
	void writeLog(string log) // Dùng để hiển thị thông tin debug
	void changeProxy(string proxyConfig) //Change proxy, truyền vào chuỗi rỗng "" để remove proxy
	string getCurrentIP() //Hiển thị địa chỉ IP hiện tại
	List<MimeMessage> getAllMails(string mailServer, int port, string mail, string password) //Đọc email IMAP
#endregion
#region Các hàm trong ADBHelper

void Delay(double delayTime);
string ExecuteCMD(string cmdCommand);
string ExecuteCMDBat(string deviceID, string cmdCommand);
Point? FindImage(string deviceID, string ImagePath, int delayPerCheck = 2000, int count = 5);
bool FindImageAndClick(string deviceID, string ImagePath, int delayPerCheck = 2000, int count = 5);
string GetDeviceName(string deviceID);
List<string> GetDevices();
Point GetScreenResolution(string deviceID);
void InputText(string deviceID, string text);
void Key(string deviceID, ADBKeyEvent key);
void LongPress(string deviceID, int x, int y, int duration = 100);
void PlanModeOFF(string deviceID, CancellationToken cancellationToken);
void PlanModeON(string deviceID, CancellationToken cancellationToken);
Bitmap ScreenShoot(string deviceID = null, bool isDeleteImageAfterCapture = true, string fileName = "screenShoot.png");
string SetADBFolderPath(string folderPath);
void Swipe(string deviceID, int x1, int y1, int x2, int y2, int duration = 100);
void SwipeByPercent(string deviceID, double x1, double y1, double x2, double y2, int duration = 100);
void Tap(string deviceID, int x, int y, int count = 1);
void TapByPercent(string deviceID, double x, double y, int count = 1);
void SetTextFromClipboard(string deviceID, string text);
#endregion
#region HTTP Request
// Hỗ trợ HTTP request bằng thư viện xNet 3.3.3
// https://teamcodedao.com/forum/index.php?/topic/3-huong-dan-co-ban-ve-thu-vien-xnet-trong-csharp/
#endregion
#region Xử lý JSON data
// Hỗ trợ xử lý JSON data bằng thư viện Newtonsoft.Json;
#endregion