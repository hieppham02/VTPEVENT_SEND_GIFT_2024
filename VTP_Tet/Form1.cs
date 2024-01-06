using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using Newtonsoft.Json;
using Leaf.xNet;
using System.IO;
using System.Security.Policy;
using Newtonsoft.Json.Linq;
using static System.Net.WebRequestMethods;
using RestSharp;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Web.UI.WebControls;
using System.Runtime.Remoting.Contexts;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace VTP_Tet
{
    public partial class fMain : Form
    {
        #region Global variable
        string connectionString = "Data Source=VTP.db;Version=3;";
        private SQLiteDataAdapter dataAdapter;
        private DataTable dataTable;
        private BackgroundWorker backgroundWorker;
        SQLiteConnection connection;
        bool flag = true;
        int count = 0;
        int delay = 0;
        string proxyClient = null;
        CancellationTokenSource cts;
        CancellationTokenSource ctsListItems;
        CancellationTokenSource ctsGiveGifts;
        CancellationTokenSource ctsGetReward;
        #endregion

        #region Form control
        public fMain()
        {
            InitializeComponent();
            connection = new SQLiteConnection(connectionString);
            connection.Open();
            checkBox1.CheckedChanged += new EventHandler(checkBox1_CheckedChanged);
        }
        private void btn_loadData_Click(object sender, EventArgs e)
        {
            DisplayData();
            lb_2.Text = dataTable.Rows.Count.ToString();
        }
        private void btn_Test_Click(object sender, EventArgs e)
        {
            cts = new CancellationTokenSource();
            Task.Run(() =>
            {
                try
                {
                    flag = false;
                    delay = Int32.Parse(nmr_delay.Value.ToString());
                    int numTasks = Int32.Parse(nm_thread.Value.ToString());
                    List<Task> tasks = new List<Task>();

                    for (int taskIndex = 0; taskIndex < numTasks; taskIndex++)
                    {
                        if (flag)
                        {
                            break;
                        }
                        int startingIndex = taskIndex;
                        tasks.Add(Task.Run(() =>
                        {
                            Console.WriteLine($"Task {taskIndex + 1} is running...");
                            CancellationToken token = cts.Token;

                            for (int i = startingIndex; i < dataTable.Rows.Count; i += numTasks)
                            {

                                if (token.IsCancellationRequested)
                                {
                                    //MessageBox.Show("STOPPED");
                                    break;
                                }

                                Thread.Sleep(delay);

                                string username = dtg_vtm.Rows[i].Cells["col_username"].Value.ToString();
                                string imei = dtg_vtm.Rows[i].Cells["col_imei"].Value.ToString();
                                string token_ = dtg_vtm.Rows[i].Cells["col_token"].Value.ToString();

                                // Invoke để thay đổi giao diện người dùng
                                Invoke((MethodInvoker)delegate
                                {
                                    dtg_vtm.Rows[i].Cells["col_status"].Value = "Đang tiến hành điểm danh...";
                                });

                                try
                                {
                                    DiemDanh(username, imei, token_, i);
                                }
                                catch (Exception ex)
                                {
                                    // Xử lý ngoại lệ tại đây
                                    Console.WriteLine($"Exception: {ex.Message}");
                                }
                            }
                        }));
                    }
                    Task completionTask = Task.WhenAll(tasks);
                    // Gắn kết một hành động vào completionTask để hiển thị thông báo
                    completionTask.ContinueWith((completedTask) =>
                    {
                        MessageBox.Show("Thành công");
                    });
                    Task.WaitAll(tasks.ToArray());
                }
                catch (Exception ex)
                {
                    cts?.Cancel();
                    Console.WriteLine($"Global Exception: {ex.Message}");
                }
            });
        }
        private void btn_getListItems_Click(object sender, EventArgs e)
        {
            ctsListItems = new CancellationTokenSource();

            Task.Run(() =>
            {
                try
                {
                    flag = false;
                    delay = Int32.Parse(nmr_delay.Value.ToString());
                    int numTasks = Int32.Parse(nm_thread.Value.ToString());
                    List<Task> tasks = new List<Task>();

                    for (int taskIndex = 0; taskIndex < numTasks; taskIndex++)
                    {
                        if (flag)
                        {
                            break;
                        }
                        int startingIndex = taskIndex;
                        tasks.Add(Task.Run(() =>
                        {
                            CancellationToken token = ctsListItems.Token;

                            for (int i = startingIndex; i < dataTable.Rows.Count; i += numTasks)
                            {
                                if (token.IsCancellationRequested)
                                {
                                    // Dừng lại nếu có yêu cầu hủy bỏ
                                    break;
                                }

                                Thread.Sleep(delay);

                                string username = dtg_vtm.Rows[i].Cells["col_username"].Value.ToString();
                                string imei = dtg_vtm.Rows[i].Cells["col_imei"].Value.ToString();
                                string tokenValue = dtg_vtm.Rows[i].Cells["col_token"].Value.ToString();

                                Invoke((MethodInvoker)delegate
                                {
                                    dtg_vtm.Rows[i].Cells["col_status"].Value = "Đang tiến hành lấy list vật phẩm...";
                                });

                                try
                                {
                                    LayListVatpham(username, imei, tokenValue, i);
                                }
                                catch (Exception ex)
                                {
                                    // Xử lý ngoại lệ tại đây
                                    Console.WriteLine($"Exception: {ex.Message}");
                                }
                            }
                        }));
                    }
                    Task completionTask = Task.WhenAll(tasks);
                    // Gắn kết một hành động vào completionTask để hiển thị thông báo
                    completionTask.ContinueWith((completedTask) =>
                    {
                        MessageBox.Show("Thành công");
                    });
                    Task.WaitAll(tasks.ToArray());
                    Task.WaitAll(tasks.ToArray());
                }
                catch (Exception ex)
                {
                    ctsListItems?.Cancel();
                    Console.WriteLine($"Global Exception: {ex.Message}");
                }
            });
        }
        private void btn_sendGift_Click(object sender, EventArgs e)
        {
            ctsGiveGifts = new CancellationTokenSource();

            Task.Run(() =>
            {
                try
                {
                    flag = false;
                    int combo = 9999999;

                    if (cb_combo99k.Checked)
                    {
                        combo = 0;
                    }
                    else if (cb_combo9k.Checked)
                    {
                        combo = 1;
                    }
                    else if (cb_combo999d.Checked)
                    {
                        combo = 2;
                    }

                    delay = Int32.Parse(nmr_delay.Value.ToString());
                    int numTasks = Int32.Parse(nm_thread.Value.ToString());
                    List<Task> tasks = new List<Task>();

                    for (int taskIndex = 0; taskIndex < numTasks; taskIndex++)
                    {
                        if (flag)
                        {
                            break;
                        }
                        int startingIndex = taskIndex;
                        tasks.Add(Task.Run(() =>
                        {
                            CancellationToken token = ctsGiveGifts.Token;

                            for (int i = startingIndex; i < dataTable.Rows.Count; i += numTasks)
                            {
                                if (token.IsCancellationRequested)
                                {
                                    // Dừng lại nếu có yêu cầu hủy bỏ
                                    break;
                                }
                                if (tb_sdtgift == null)
                                {
                                    MessageBox.Show("Thiếu số cần tặng");
                                    break;

                                }
                                Thread.Sleep(1000);

                                string username = dtg_vtm.Rows[i].Cells["col_username"].Value.ToString();
                                string imei = dtg_vtm.Rows[i].Cells["col_imei"].Value.ToString();
                                string tokenValue = dtg_vtm.Rows[i].Cells["col_token"].Value.ToString();

                                Invoke((MethodInvoker)delegate
                                {
                                    dtg_vtm.Rows[i].Cells["col_status"].Value = "Đang tiến hành tặng quà...";
                                });

                                try
                                {
                                    if (cb_allCombo.Checked)
                                    {
                                        GiveAllGifts(username, imei, tokenValue, i);
                                    }
                                    else
                                    {

                                        GiveCombo(username, imei, tokenValue, i, combo);

                                    }
                                }
                                catch (Exception ex)
                                {
                                    // Xử lý ngoại lệ tại đây
                                    Console.WriteLine($"Exception: {ex.Message}");
                                }
                            }
                        }));
                    }
                    //Task completionTask = Task.WhenAll(tasks);
                    //// Gắn kết một hành động vào completionTask để hiển thị thông báo
                    //completionTask.ContinueWith((completedTask) =>
                    //{
                    //    MessageBox.Show("Thành công");
                    //});
                    //Task.WaitAll(tasks.ToArray());
                    //Task.WaitAll(tasks.ToArray());
                }
                catch (Exception ex)
                {
                    ctsGiveGifts?.Cancel();
                    Console.WriteLine($"Global Exception: {ex.Message}");
                }
            });
        }
        private void btn_stop_Click(object sender, EventArgs e)
        {
            cts?.Cancel();
            ctsListItems?.Cancel();
            ctsGiveGifts?.Cancel();
            ctsGetReward?.Cancel();
        }
        private void btn_openGifts_Click(object sender, EventArgs e)
        {
            ctsGetReward = new CancellationTokenSource();

            Task.Run(() =>
            {
                try
                {
                    int code = 0;
                    flag = false;
                    delay = Int32.Parse(nmr_delay.Value.ToString());

                    if (cb_combo99k.Checked)
                    {
                        code = 309;
                    }
                    else if (cb_combo9k.Checked)
                    {
                        code = 306;
                    }
                    else if (cb_combo999d.Checked)
                    {
                        code = 303;
                    }

                    int numTasks = Int32.Parse(nm_thread.Value.ToString());
                    List<Task> tasks = new List<Task>();

                    for (int taskIndex = 0; taskIndex < numTasks; taskIndex++)
                    {
                        if (flag)
                        {
                            break;
                        }

                        int startingIndex = taskIndex;
                        tasks.Add(Task.Run(() =>
                        {
                            CancellationToken token = ctsGetReward.Token;

                            for (int i = startingIndex; i < dataTable.Rows.Count; i += numTasks)
                            {
                                if (token.IsCancellationRequested)
                                {
                                    // Dừng lại nếu có yêu cầu hủy bỏ
                                    break;
                                }

                                Thread.Sleep(1000);

                                string username = dtg_vtm.Rows[i].Cells["col_username"].Value.ToString();
                                string imei = dtg_vtm.Rows[i].Cells["col_imei"].Value.ToString();
                                string tokenValue = dtg_vtm.Rows[i].Cells["col_token"].Value.ToString();

                                Invoke((MethodInvoker)delegate
                                {
                                    dtg_vtm.Rows[i].Cells["col_status"].Value = "Đang tiến hành mở quà...";
                                });

                                try
                                {
                                    if (code == 0)
                                    {
                                        Invoke((MethodInvoker)delegate
                                        {
                                            MessageBox.Show("Chưa chọn combo");
                                            flag = true;
                                        });
                                        break;
                                    }
                                    else
                                    {
                                        GetReward(username, imei, tokenValue, i, code);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    // Xử lý ngoại lệ tại đây
                                    Console.WriteLine($"Exception: {ex.Message}");
                                }
                            }
                        }));
                    }
                    Task completionTask = Task.WhenAll(tasks);
                    // Gắn kết một hành động vào completionTask để hiển thị thông báo
                    completionTask.ContinueWith((completedTask) =>
                    {
                        MessageBox.Show("Thành công");
                    });
                    Task.WaitAll(tasks.ToArray());
                    Task.WaitAll(tasks.ToArray());
                }
                catch (Exception ex)
                {
                    ctsGetReward?.Cancel();
                    Console.WriteLine($"Global Exception: {ex.Message}");
                }
            });
        }
        private void btn_changeIP_Click(object sender, EventArgs e)
        {
            proxyClient = tb_proxyKey.Text;
        }
        private void btn_selectBlacklist_Click(object sender, EventArgs e)
        {
            SelectBlacklist();
        }
        private void cb_combo99k_CheckedChanged(object sender, EventArgs e)
        {
            cb_combo9k.Checked = false;
            cb_combo999d.Checked = false;
            cb_allCombo.Checked = false;
        }
        private void cb_combo9k_CheckedChanged(object sender, EventArgs e)
        {
            cb_combo99k.Checked = false;
            cb_combo999d.Checked = false;
            cb_allCombo.Checked = false;
        }
        private void cb_combo999d_CheckedChanged(object sender, EventArgs e)
        {
            cb_combo99k.Checked = false;
            cb_combo9k.Checked = false;
            cb_allCombo.Checked = false;
        }
        private void cb_allCombo_CheckedChanged(object sender, EventArgs e)
        {
            cb_combo99k.Checked = false;
            cb_combo9k.Checked = false;
            cb_combo999d.Checked = false;
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                this.BackColor = Color.FromArgb(30, 30, 30); // Màu RGB (30, 30, 30)
                groupBox1.BackColor = Color.FromArgb(30, 30, 30);
                groupBox1.ForeColor = Color.White;
                groupBox2.BackColor = Color.FromArgb(30, 30, 30);
                groupBox2.ForeColor = Color.White;
                groupBox3.BackColor = Color.FromArgb(30, 30, 30);
                groupBox3.ForeColor = Color.White;
                groupBox4.BackColor = Color.FromArgb(30, 30, 30);
                groupBox4.ForeColor = Color.White;
                groupBox5.BackColor = Color.FromArgb(30, 30, 30);
                groupBox5.ForeColor = Color.White;
                nm_thread.BackColor = Color.FromArgb(30, 30, 30);
                nm_thread.ForeColor = Color.White;
                //dtg_vtm.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
                //dtg_vtm.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                //dtg_vtm.BackgroundColor = Color.FromArgb(56, 56, 56);
                //dtg_vtm.EnableHeadersVisualStyles = false;
            }
            else
            {
                // Đặt màu nền về mặc định nếu CheckBox không được tích vào
                this.BackColor = SystemColors.Control;
                groupBox1.BackColor = Color.White;
                groupBox1.ForeColor = Color.Black;
                groupBox2.BackColor = Color.White;
                groupBox2.ForeColor = Color.Black;
                groupBox3.BackColor = Color.White;
                groupBox3.ForeColor = Color.Black;
                groupBox4.BackColor = Color.White;
                groupBox4.ForeColor = Color.Black;
                groupBox5.BackColor = Color.White;
                groupBox5.ForeColor = Color.Black;
                nm_thread.BackColor = Color.White;
                nm_thread.ForeColor = Color.Black;
                //dtg_vtm.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
                //dtg_vtm.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                //dtg_vtm.BackgroundColor = Color.FromArgb(224, 224, 224);
                //dtg_vtm.EnableHeadersVisualStyles = false;
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            ChromeOptions options = new ChromeOptions();
            service.HideCommandPromptWindow = true;
            ChromeDriver driver = new ChromeDriver(service);
            driver.Navigate().GoToUrl("https://t.me/stewie6969");
        }
        #endregion

        #region Functions
        public void UpdateDatabase(string username, string content)
        {
            string query = $"UPDATE VTMData SET status=@status WHERE username=@username";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@status", content);
            command.Parameters.AddWithValue("@username", username);
            command.ExecuteNonQuery();
        }
        public void UpdateItemsDatabase(string username, List<int> items)
        {
            int dao = items[0];
            int mai = items[1];
            int quat = items[2];
            int tranh = items[3];
            int den = items[4];
            int chuoi = items[5];
            int buoi = items[6];
            int phat = items[7];
            int cam = items[8];
            int luu = items[9];
            int chung = items[10];
            int xoi = items[11];
            int gio = items[12];
            int ga = items[13];
            int canh = items[14];
            string query = @"
            UPDATE VTMData
            SET 
                PEACH_BLOSSOM = @PEACH_BLOSSOM,
                APRICOT_BLOSSOM = @APRICOT_BLOSSOM,
                KUMQUAT = @KUMQUAT,
                WALL_PAINTING = @WALL_PAINTING,
                LANTERN = @LANTERN,
                BANANA = @BANANA,
                GRAPEFRUIT = @GRAPEFRUIT,
                BUDDHA = @BUDDHA,
                ORANGE = @ORANGE,
                POMEGRANATE = @POMEGRANATE,
                CHUNG_CAKE = @CHUNG_CAKE,
                STICKY_RICE = @STICKY_RICE,
                SILK_ROLL = @SILK_ROLL,
                BOILED_CKICKEN = @BOILED_CKICKEN,
                BAMBOO_SHOOT_SOUP = @BAMBOO_SHOOT_SOUP
            WHERE 
                username = @username";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@PEACH_BLOSSOM", dao);
            command.Parameters.AddWithValue("@APRICOT_BLOSSOM", mai);
            command.Parameters.AddWithValue("@KUMQUAT", quat);
            command.Parameters.AddWithValue("@WALL_PAINTING", tranh);
            command.Parameters.AddWithValue("@LANTERN", den);
            command.Parameters.AddWithValue("@BANANA", chuoi);
            command.Parameters.AddWithValue("@GRAPEFRUIT", buoi);
            command.Parameters.AddWithValue("@BUDDHA", phat);
            command.Parameters.AddWithValue("@ORANGE", cam);
            command.Parameters.AddWithValue("@POMEGRANATE", luu);
            command.Parameters.AddWithValue("@CHUNG_CAKE", chung);
            command.Parameters.AddWithValue("@STICKY_RICE", xoi);
            command.Parameters.AddWithValue("@SILK_ROLL", gio);
            command.Parameters.AddWithValue("@BOILED_CKICKEN", ga);
            command.Parameters.AddWithValue("@BAMBOO_SHOOT_SOUP", canh);
            command.Parameters.AddWithValue("@username", username);
            command.ExecuteNonQuery();
        }
        public int GetItemsFromDatabase(string username, string giftCodeName)
        {
            string query = $"SELECT {giftCodeName} FROM VTMData WHERE {giftCodeName} = 1 LIMIT 1";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@username", username);
            int quantity = command.ExecuteNonQuery();
            return quantity;
        }
        public void GetCombo99k()
        {
            dataTable = new DataTable();
            string[] listExcept = System.IO.File.ReadAllLines("Import/data.txt");
            List<string> giftCode = new List<string>() { "PEACH_BLOSSOM", "APRICOT_BLOSSOM", "KUMQUAT", "WALL_PAINTING", "LANTERN" };
            foreach (string code in giftCode)
            {
                string query = $"SELECT id, username, imei, session, status FROM VTMData WHERE {code} = 1 AND username NOT IN ('{string.Join("', '", listExcept)}') LIMIT 1";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                dataAdapter = new SQLiteDataAdapter(command);
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dataTable);
            }
            dtg_vtm.DataSource = dataTable;
        }
        public void GetCombo9k()
        {
            dataTable = new DataTable();
            string[] listExcept = System.IO.File.ReadAllLines("Import/data.txt");
            List<string> giftCode = new List<string>() { "BANANA", "GRAPEFRUIT", "BUDDHA", "ORANGE", "POMEGRANATE" };
            foreach (string code in giftCode)
            {
                string query = $"SELECT id, username, imei, session, status FROM VTMData WHERE {code} = 1 AND username NOT IN ('{string.Join("', '", listExcept)}') LIMIT 1";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                dataAdapter = new SQLiteDataAdapter(command);
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dataTable);
            }
            dtg_vtm.DataSource = dataTable;
        }
        public void GetCombo999d()
        {
            dataTable = new DataTable();
            string[] listExcept = System.IO.File.ReadAllLines("Import/data.txt");
            List<string> giftCode = new List<string>() { "CHUNG_CAKE", "STICKY_RICE", "SILK_ROLL", "BOILED_CKICKEN", "BAMBOO_SHOOT_SOUP" };
            foreach (string code in giftCode)
            {
                string query = $"SELECT id, username, imei, session, status FROM VTMData WHERE {code} = 1 AND username NOT IN ('{string.Join("', '", listExcept)}') LIMIT 1";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                dataAdapter = new SQLiteDataAdapter(command);
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dataTable);
            }
            dtg_vtm.DataSource = dataTable;
        }
        public void GetAllCombo()
        {
            dataTable = new DataTable();
            string[] listExcept = System.IO.File.ReadAllLines("Import/data.txt");
            List<string> giftCode = new List<string>() { "PEACH_BLOSSOM", "APRICOT_BLOSSOM", "KUMQUAT", "WALL_PAINTING", "LANTERN", "BANANA", "GRAPEFRUIT", "BUDDHA", "ORANGE", "POMEGRANATE", "CHUNG_CAKE", "STICKY_RICE", "SILK_ROLL", "BOILED_CKICKEN", "BAMBOO_SHOOT_SOUP" };
            foreach (string code in giftCode)
            {
                string query = $"SELECT id, username, imei, session, status FROM VTMData WHERE {code} = 1 AND username NOT IN ('{string.Join("', '", listExcept)}') LIMIT 1";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                dataAdapter = new SQLiteDataAdapter(command);
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dataTable);
            }
            dtg_vtm.DataSource = dataTable;
        }
        public string SendGift(string sdt, string imei, string token, string ssid, string giftCode)
        {
            using (HttpRequest request = new HttpRequest())
            {
                if (proxyClient != null)
                {
                    request.Proxy = HttpProxyClient.Parse(proxyClient);
                }
                request.AddHeader("Authorization", $"Bearer {token}");
                request.AddHeader("App-Version", "6.8.10");
                request.AddHeader("Channel", "APP");
                request.AddHeader("Product", "VIETTELPAY");
                request.AddHeader("Type-Os", "ios");
                request.AddHeader("Accept-Language", "vi");
                request.AddHeader("Imei", $"{imei}");
                request.AddHeader("Sessionid", $"{ssid}");
                request.AddHeader("Device-Name", "iPhone");
                request.AddHeader("User-Agent", "Viettel Money/6.8.10 (com.viettel.viettelpay; build:1; iOS 17.0.1) Alamofire/6.8.10");
                request.AddHeader("Os-Version", "17.0.1");
                request.AddHeader("Authority-Party", "APP");
                string value = DateTime.Now.AddHours(1.0).ToString("yyyyMMddhhmmss");
                string payload = "{\"app_name\":\"VIETTELPAY\",\"toMsisdn\":\"" + sdt + "\",\"app_version\":\"6.8.10\",\"type_os\":\"ios\",\"giftSetCode\":\"" + giftCode + "\",\"order_id\":\"" + value + "\",\"imei\":\"" + imei + "\"}";
                HttpResponse response = request.Post("https://api8.viettelpay.vn/game/game2021-api/public/v2/api/digital-kingdom/give-gift", payload, "application/json");
                return response.ToString();
            }
        }
        public void DisplayData()
        {
            string query = null;
            string offset = tb_offset.Text;
            if (rb_all.Checked)
            {
                string[] listExcept = System.IO.File.ReadAllLines("Import/data.txt");
                query = $"SELECT id, username, imei, session, status FROM VTMData WHERE Username NOT IN ('{string.Join("', '", listExcept)}')";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                dataAdapter = new SQLiteDataAdapter(command);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dtg_vtm.DataSource = dataTable;
                for (int i = 0; i < dtg_vtm.Rows.Count; i++)
                {
                    dtg_vtm.Rows[i].Cells["col_stt"].Value = i + 1;
                }
            }
            if (rb_single.Checked)
            {
                string[] listExcept = System.IO.File.ReadAllLines("Import/data.txt");
                query = $"SELECT id, username, imei, session, status FROM VTMData WHERE Username NOT IN ('{string.Join("', '", listExcept)}') ORDER BY id LIMIT 100 OFFSET {offset}";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                dataAdapter = new SQLiteDataAdapter(command);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dtg_vtm.DataSource = dataTable;
                //for (int i = 0; i < dtg_vtm.Rows.Count; i++)
                //{
                //    dtg_vtm.Rows[i].Cells["col_stt"].Value = i + 1;
                //}
            }
            if (rb_selectcombo.Checked)
            {
                if (cb_combo99k.Checked)
                {
                    GetCombo99k();
                }
                if (cb_combo9k.Checked)
                {
                    GetCombo9k();
                }
                if (cb_combo999d.Checked)
                {
                    GetCombo999d();
                }
                if (cb_allCombo.Checked)
                {
                    GetAllCombo();
                }
            }
        }
        public void DiemDanh(string username, string imei, string token, int index)
        {
            Task.Run(async () =>
            {
                try
                {
                    await Task.Delay(delay);
                    string value = DateTime.Now.AddHours(1.0).ToString("yyyyMMddhhmmss");
                    using (HttpRequest request = new HttpRequest())
                    {
                        if (proxyClient != null)
                        {
                            request.Proxy = HttpProxyClient.Parse(proxyClient);
                        }
                        request.AddHeader("Authorization", $"Bearer {token}");
                        request.AddHeader("App-Version", "6.8.10");
                        request.AddHeader("Product", "VIETTELPAY");
                        request.AddHeader("Type-Os", "ios");
                        request.AddHeader("Accept-Language", "vi");
                        request.AddHeader("Imei", $"{imei}");
                        request.AddHeader("Device-Name", "iPhone");
                        request.AddHeader("User-Agent", "Viettel Money/6.8.10 (com.viettel.viettelpay; build:1; iOS 17.0.1) Alamofire/6.8.10");
                        request.AddHeader("Os-Version", "17.0.1");
                        request.AddHeader("Authority-Party", "APP");
                        HttpResponse response = request.Get("https://api8.viettelpay.vn/customer/v1/accounts?home-version=2.0&post-check=1&recommendations=1&sources=1");
                        JToken jToken = JToken.Parse(response.ToString());
                        string ssid = jToken.SelectToken("data.otherData.sessionId")?.Value<string>();
                        if (ssid != null)
                        {
                            request.AddHeader("Sec-Fetch-Site", "same-origin");
                            request.AddHeader("Accept-Language", "vi-VN,vi;q=0.9");
                            request.AddHeader("Sec-Fetch-Mode", "cors");
                            request.AddHeader("Sessionid", ssid);
                            request.AddHeader("User-Agent", "Mozilla/5.0 (iPhone; CPU iPhone OS 17_0_1 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/15E148");
                            request.AddHeader("Referer", "https://api24cdn.vtmoney.vn/campaign/digital-kingdom-webview/home-2024/event-hub?isFirstTime=false");
                            request.AddHeader("Sec-Fetch-Dest", "empty");
                            HttpResponse response_ = request.Get("https://api24cdn.vtmoney.vn/game/game2021-api/public/v2/api/digital-kingdom/check-visits-and-gift");
                            CheckVisitResponse checkVisit = JsonConvert.DeserializeObject<CheckVisitResponse>(response_.ToString());
                            string status = checkVisit.status.message;
                            Invoke((MethodInvoker)delegate
                            {
                                if (status == "Thành công")
                                {
                                    LayListVatpham_Hidden(username, imei, token, index);
                                    List<Gift> gifts = checkVisit.data.gifts;
                                    if (gifts != null)
                                    {
                                        string giftName = checkVisit.data.gifts[0].giftName.ToString();
                                        dtg_vtm.Rows[index].Cells["col_status"].Value = $"{status.ToString()} => Bạn đã nhận được 1 vật phẩm: {giftName}";
                                    }
                                    else
                                    {
                                        dtg_vtm.Rows[index].Cells["col_status"].Value = $"{status.ToString()} => Đã điểm danh";
                                    }
                                }
                                else
                                {
                                    dtg_vtm.Rows[index].Cells["col_status"].Value = $"{status.ToString()}";
                                }
                                UpdateDatabase(username, response_.ToString());
                            });
                        }
                        else
                        {
                            Invoke((MethodInvoker)delegate
                            {
                                dtg_vtm.Rows[index].Cells["col_status"].Value = response.ToString();
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        flag = true;
                        dtg_vtm.Rows[index].Cells["col_status"].Value = ex.ToString();
                    });
                }
            });
        }
        public void LayListVatpham(string username, string imei, string token, int index)
        {
            Task.Run(async () =>
            {
                try
                {
                    string items = null;
                    await Task.Delay(delay);
                    string value = DateTime.Now.AddHours(1.0).ToString("yyyyMMddhhmmss");
                    using (HttpRequest request = new HttpRequest())
                    {
                        if (proxyClient != null)
                        {
                            request.Proxy = HttpProxyClient.Parse(proxyClient);
                        }
                        request.AddHeader("Authorization", $"Bearer {token}");
                        request.AddHeader("App-Version", "6.8.10");
                        request.AddHeader("Product", "VIETTELPAY");
                        request.AddHeader("Type-Os", "ios");
                        request.AddHeader("Accept-Language", "vi");
                        request.AddHeader("Imei", $"{imei}");
                        request.AddHeader("Device-Name", "iPhone");
                        request.AddHeader("User-Agent", "Viettel Money/6.8.10 (com.viettel.viettelpay; build:1; iOS 17.0.1) Alamofire/6.8.10");
                        request.AddHeader("Os-Version", "17.0.1");
                        request.AddHeader("Authority-Party", "APP");
                        HttpResponse response = request.Get("https://api8.viettelpay.vn/customer/v1/accounts?home-version=2.0&post-check=1&recommendations=1&sources=1");
                        JToken jToken = JToken.Parse(response.ToString());
                        string ssid = jToken.SelectToken("data.otherData.sessionId")?.Value<string>();
                        if (ssid != null)
                        {
                            request.AddHeader("Accept", "application/json, text/plain, */*");
                            request.AddHeader("Sec-Fetch-Site", "same-origin");
                            request.AddHeader("Accept-Language", "vi-VN,vi;q=0.9");
                            request.AddHeader("Sec-Fetch-Mode", "cors");
                            request.AddHeader("Sessionid", ssid);
                            request.AddHeader("User-Agent", "Mozilla/5.0 (iPhone; CPU iPhone OS 17_0_1 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/15E148");
                            request.AddHeader("Referer", "https://api24cdn.vtmoney.vn/campaign/digital-kingdom-webview/home-2024/items-box?prevUrl=home-2024%2Fevent-hub");
                            request.AddHeader("Sec-Fetch-Dest", "empty");
                            response = request.Get("https://api24cdn.vtmoney.vn/game/game2021-api/public/v2/api/digital-kingdom/get-gift-set/list?programCode=SAM_TET_2024");
                            GiftSet giftSet = JsonConvert.DeserializeObject<GiftSet>(response.ToString());
                            string status = giftSet.status.code;
                            Invoke((MethodInvoker)delegate
                            {
                                if (status == "00")
                                {
                                    List<GiftSetType> giftSetType = giftSet.data.giftSetTypes;
                                    List<int> itemsArray = new List<int>();
                                    foreach (GiftSetType gift in giftSetType)
                                    {
                                        List<GiftSetInfo> giftSetInfoList = gift.giftSetInfo;
                                        foreach (GiftSetInfo giftSetInfo in giftSetInfoList)
                                        {
                                            itemsArray.Add(giftSetInfo.quantity);
                                            if (giftSetInfo.quantity > 0)
                                            {
                                                items += $" [{giftSetInfo.quantity}|{giftSetInfo.giftSetName}] ";
                                            }
                                        }
                                    }
                                    UpdateDatabase(username, items);
                                    UpdateItemsDatabase(username, itemsArray);
                                    if (items != null)
                                    {
                                        dtg_vtm.Rows[index].Cells["col_status"].Value = items;
                                    }
                                    else
                                    {
                                        dtg_vtm.Rows[index].Cells["col_status"].Value = "Hết vật phẩm";
                                        UpdateDatabase(username, "Hết vật phẩm");
                                    }
                                }
                                else
                                {
                                    dtg_vtm.Rows[index].Cells["col_status"].Value = response.ToString();
                                }
                            });
                        }
                        else
                        {
                            dtg_vtm.Rows[index].Cells["col_status"].Value = response.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        flag = true;
                        dtg_vtm.Rows[index].Cells["col_status"].Value = ex.ToString();
                    });
                }
            });
        }
        public void LayListVatpham_Hidden(string username, string imei, string token, int index)
        {
            Task.Run(async () =>
            {
                try
                {
                    string items = null;
                    //dtg_vtm.Rows[index].Cells["col_status"].Value = "Đang tiến hành điểm danh";
                    await Task.Delay(delay);
                    string value = DateTime.Now.AddHours(1.0).ToString("yyyyMMddhhmmss");
                    using (HttpRequest request = new HttpRequest())
                    {
                        if (proxyClient != null)
                        {
                            request.Proxy = HttpProxyClient.Parse(proxyClient);
                        }
                        request.AddHeader("Authorization", $"Bearer {token}");
                        request.AddHeader("App-Version", "6.8.10");
                        request.AddHeader("Product", "VIETTELPAY");
                        request.AddHeader("Type-Os", "ios");
                        request.AddHeader("Accept-Language", "vi");
                        request.AddHeader("Imei", $"{imei}");
                        request.AddHeader("Device-Name", "iPhone");
                        request.AddHeader("User-Agent", "Viettel Money/6.8.10 (com.viettel.viettelpay; build:1; iOS 17.0.1) Alamofire/6.8.10");
                        request.AddHeader("Os-Version", "17.0.1");
                        request.AddHeader("Authority-Party", "APP");
                        HttpResponse response = request.Get("https://api8.viettelpay.vn/customer/v1/accounts?home-version=2.0&post-check=1&recommendations=1&sources=1");
                        JToken jToken = JToken.Parse(response.ToString());
                        string ssid = jToken.SelectToken("data.otherData.sessionId")?.Value<string>();
                        if (ssid != null)
                        {
                            request.AddHeader("Accept", "application/json, text/plain, */*");
                            request.AddHeader("Sec-Fetch-Site", "same-origin");
                            request.AddHeader("Accept-Language", "vi-VN,vi;q=0.9");
                            request.AddHeader("Sec-Fetch-Mode", "cors");
                            request.AddHeader("Sessionid", ssid);
                            request.AddHeader("User-Agent", "Mozilla/5.0 (iPhone; CPU iPhone OS 17_0_1 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/15E148");
                            request.AddHeader("Referer", "https://api24cdn.vtmoney.vn/campaign/digital-kingdom-webview/home-2024/items-box?prevUrl=home-2024%2Fevent-hub");
                            request.AddHeader("Sec-Fetch-Dest", "empty");
                            response = request.Get("https://api24cdn.vtmoney.vn/game/game2021-api/public/v2/api/digital-kingdom/get-gift-set/list?programCode=SAM_TET_2024");
                            GiftSet giftSet = JsonConvert.DeserializeObject<GiftSet>(response.ToString());
                            string status = giftSet.status.code;
                            Invoke((MethodInvoker)delegate
                            {
                                if (status == "00")
                                {
                                    List<GiftSetType> giftSetType = giftSet.data.giftSetTypes;
                                    List<int> itemsArray = new List<int>();
                                    foreach (GiftSetType gift in giftSetType)
                                    {
                                        List<GiftSetInfo> giftSetInfoList = gift.giftSetInfo;
                                        foreach (GiftSetInfo giftSetInfo in giftSetInfoList)
                                        {
                                            itemsArray.Add(giftSetInfo.quantity);
                                            if (giftSetInfo.quantity > 0)
                                            {
                                                items += $" [{giftSetInfo.quantity}|{giftSetInfo.giftSetName}] ";
                                            }
                                        }
                                    }
                                    UpdateItemsDatabase(username, itemsArray);
                                    if (items != null)
                                    {
                                        UpdateDatabase(username, items);
                                    }
                                    else
                                    {
                                        UpdateDatabase(username, "Hết vật phẩm");
                                    }
                                }
                                else
                                {
                                    dtg_vtm.Rows[index].Cells["col_status"].Value = response.ToString();
                                }
                            });
                        }
                        else
                        {
                            dtg_vtm.Rows[index].Cells["col_status"].Value = response.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        flag = true;
                        dtg_vtm.Rows[index].Cells["col_status"].Value = ex.ToString();
                    });
                }
            });
        }
        public void GiveAllGifts(string username, string imei, string token, int index)
        {
            Task.Run(async () =>
            {
                try
                {
                    using (HttpRequest request = new HttpRequest())
                    {
                        string sdt = tb_sdtgift.Text;
                        await Task.Delay(delay);
                        if (proxyClient != null)
                        {
                            request.Proxy = HttpProxyClient.Parse(proxyClient);
                        }
                        request.AddHeader("Authorization", $"Bearer {token}");
                        request.AddHeader("App-Version", "6.8.10");
                        request.AddHeader("Product", "VIETTELPAY");
                        request.AddHeader("Type-Os", "ios");
                        request.AddHeader("Accept-Language", "vi");
                        request.AddHeader("Imei", $"{imei}");
                        request.AddHeader("Device-Name", "iPhone");
                        request.AddHeader("User-Agent", "Viettel Money/6.8.10 (com.viettel.viettelpay; build:1; iOS 17.0.1) Alamofire/6.8.10");
                        request.AddHeader("Os-Version", "17.0.1");
                        request.AddHeader("Authority-Party", "APP");
                        HttpResponse response = request.Get("https://api8.viettelpay.vn/customer/v1/accounts?home-version=2.0&post-check=1&recommendations=1&sources=1");
                        JToken jToken = JToken.Parse(response.ToString());
                        string ssid = jToken.SelectToken("data.otherData.sessionId")?.Value<string>();
                        if (ssid != null)
                        {
                            request.AddHeader("Accept", "application/json, text/plain, */*");
                            request.AddHeader("Sec-Fetch-Site", "same-origin");
                            request.AddHeader("Accept-Language", "vi-VN,vi;q=0.9");
                            request.AddHeader("Sec-Fetch-Mode", "cors");
                            request.AddHeader("Sessionid", ssid);
                            request.AddHeader("User-Agent", "Mozilla/5.0 (iPhone; CPU iPhone OS 17_0_1 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/15E148");
                            request.AddHeader("Referer", "https://api24cdn.vtmoney.vn/campaign/digital-kingdom-webview/home-2024/items-box?prevUrl=home-2024%2Fevent-hub");
                            request.AddHeader("Sec-Fetch-Dest", "empty");
                            response = request.Get("https://api24cdn.vtmoney.vn/game/game2021-api/public/v2/api/digital-kingdom/get-gift-set/list?programCode=SAM_TET_2024");
                            GiftSet giftSet = JsonConvert.DeserializeObject<GiftSet>(response.ToString());
                            string status = giftSet.status.code;
                            Invoke((MethodInvoker)delegate
                            {
                                if (status == "00")
                                {
                                    bool stop = false;
                                    List<GiftSetType> giftSetType = giftSet.data.giftSetTypes;
                                    foreach (GiftSetType gift in giftSetType)
                                    {
                                        if (stop == true)
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            List<GiftSetInfo> giftSetInfoList = gift.giftSetInfo;
                                            foreach (GiftSetInfo giftSetInfo in giftSetInfoList)
                                            {
                                                if (giftSetInfo.quantity > 0)
                                                {
                                                    string giftCode = giftSetInfo.giftSetCode;
                                                    request.AddHeader("Authorization", $"Bearer {token}");
                                                    request.AddHeader("App-Version", "6.8.10");
                                                    request.AddHeader("Channel", "APP");
                                                    request.AddHeader("Product", "VIETTELPAY");
                                                    request.AddHeader("Type-Os", "ios");
                                                    request.AddHeader("Accept-Language", "vi");
                                                    request.AddHeader("Imei", $"{imei}");
                                                    request.AddHeader("Sessionid", $"{ssid}");
                                                    request.AddHeader("Device-Name", "iPhone");
                                                    request.AddHeader("User-Agent", "Viettel Money/6.8.10 (com.viettel.viettelpay; build:1; iOS 17.0.1) Alamofire/6.8.10");
                                                    request.AddHeader("Os-Version", "17.0.1");
                                                    request.AddHeader("Authority-Party", "APP");
                                                    string value = DateTime.Now.AddHours(1.0).ToString("yyyyMMddhhmmss");
                                                    string payload = "{\"app_name\":\"VIETTELPAY\",\"toMsisdn\":\"" + sdt + "\",\"app_version\":\"6.8.10\",\"type_os\":\"ios\",\"giftSetCode\":\"" + giftCode + "\",\"order_id\":\"" + value + "\",\"imei\":\"" + imei + "\"}";
                                                    response = request.Post("https://api8.viettelpay.vn/game/game2021-api/public/v2/api/digital-kingdom/give-gift", payload, "application/json");
                                                    JObject json = JObject.Parse(response.ToString());
                                                    string statusCode = json["status"]["code"].ToString();
                                                    if (statusCode == "00")
                                                    {
                                                        string content = json["data"]["content"].ToString();
                                                        string resultString = Regex.Replace(content, "<.*?>", "");
                                                        dtg_vtm.Rows[index].Cells["col_status"].Value = resultString;
                                                    }
                                                    else
                                                    {
                                                        string displaymsg = json["status"]["displayMessage"].ToString();
                                                        dtg_vtm.Rows[index].Cells["col_status"].Value = displaymsg;
                                                    }
                                                    LayListVatpham_Hidden(username, imei, token, index);
                                                    stop = true;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    dtg_vtm.Rows[index].Cells["col_status"].Value = response.ToString();
                                }
                                UpdateDatabase(username, response.ToString());
                            });
                        }
                        else
                        {
                            dtg_vtm.Rows[index].Cells["col_status"].Value = response.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        flag = true;
                        dtg_vtm.Rows[index].Cells["col_status"].Value = ex.ToString();
                    });
                }
            });
        }
        public void GiveCombo(string username, string imei, string token, int index, int combo)
        {
            Task.Run(async () =>
            {
                try
                {
                    using (HttpRequest request = new HttpRequest())
                    {
                        string sdt = tb_sdtgift.Text;
                        await Task.Delay(delay);
                        if (proxyClient != null)
                        {
                            request.Proxy = HttpProxyClient.Parse(proxyClient);
                        }
                        request.AddHeader("Authorization", $"Bearer {token}");
                        request.AddHeader("App-Version", "6.8.10");
                        request.AddHeader("Product", "VIETTELPAY");
                        request.AddHeader("Type-Os", "ios");
                        request.AddHeader("Accept-Language", "vi");
                        request.AddHeader("Imei", $"{imei}");
                        request.AddHeader("Device-Name", "iPhone");
                        request.AddHeader("User-Agent", "Viettel Money/6.8.10 (com.viettel.viettelpay; build:1; iOS 17.0.1) Alamofire/6.8.10");
                        request.AddHeader("Os-Version", "17.0.1");
                        request.AddHeader("Authority-Party", "APP");
                        HttpResponse response = request.Get("https://api8.viettelpay.vn/customer/v1/accounts?home-version=2.0&post-check=1&recommendations=1&sources=1");
                        JToken jToken = JToken.Parse(response.ToString());
                        string ssid = jToken.SelectToken("data.otherData.sessionId")?.Value<string>();
                        if (ssid != null)
                        {
                            request.AddHeader("Accept", "application/json, text/plain, */*");
                            request.AddHeader("Sec-Fetch-Site", "same-origin");
                            request.AddHeader("Accept-Language", "vi-VN,vi;q=0.9");
                            request.AddHeader("Sec-Fetch-Mode", "cors");
                            request.AddHeader("Sessionid", ssid);
                            request.AddHeader("User-Agent", "Mozilla/5.0 (iPhone; CPU iPhone OS 17_0_1 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/15E148");
                            request.AddHeader("Referer", "https://api24cdn.vtmoney.vn/campaign/digital-kingdom-webview/home-2024/items-box?prevUrl=home-2024%2Fevent-hub");
                            request.AddHeader("Sec-Fetch-Dest", "empty");
                            response = request.Get("https://api24cdn.vtmoney.vn/game/game2021-api/public/v2/api/digital-kingdom/get-gift-set/list?programCode=SAM_TET_2024");
                            GiftSet giftSet = JsonConvert.DeserializeObject<GiftSet>(response.ToString());
                            string status = giftSet.status.code;
                            Invoke((MethodInvoker)delegate
                            {
                                if (status == "00")
                                {
                                    bool stop = false;
                                    List<GiftSetInfo> giftSetInfoList = giftSet.data.giftSetTypes[combo].giftSetInfo;
                                    foreach (GiftSetInfo giftSetInfo in giftSetInfoList)
                                    {
                                        if (stop == true)
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            if (giftSetInfo.quantity > 0)
                                            {
                                                string giftCode = giftSetInfo.giftSetCode;
                                                request.AddHeader("Authorization", $"Bearer {token}");
                                                request.AddHeader("App-Version", "6.8.10");
                                                request.AddHeader("Channel", "APP");
                                                request.AddHeader("Product", "VIETTELPAY");
                                                request.AddHeader("Type-Os", "ios");
                                                request.AddHeader("Accept-Language", "vi");
                                                request.AddHeader("Imei", $"{imei}");
                                                request.AddHeader("Sessionid", $"{ssid}");
                                                request.AddHeader("Device-Name", "iPhone");
                                                request.AddHeader("User-Agent", "Viettel Money/6.8.10 (com.viettel.viettelpay; build:1; iOS 17.0.1) Alamofire/6.8.10");
                                                request.AddHeader("Os-Version", "17.0.1");
                                                request.AddHeader("Authority-Party", "APP");
                                                string value = DateTime.Now.AddHours(1.0).ToString("yyyyMMddhhmmss");
                                                string payload = "{\"app_name\":\"VIETTELPAY\",\"toMsisdn\":\"" + sdt + "\",\"app_version\":\"6.8.10\",\"type_os\":\"ios\",\"giftSetCode\":\"" + giftCode + "\",\"order_id\":\"" + value + "\",\"imei\":\"" + imei + "\"}";
                                                response = request.Post("https://api8.viettelpay.vn/game/game2021-api/public/v2/api/digital-kingdom/give-gift", payload, "application/json");
                                                JObject json = JObject.Parse(response.ToString());
                                                string statusCode = json["status"]["code"].ToString();
                                                if (statusCode == "00")
                                                {
                                                    string content = json["data"]["content"].ToString();
                                                    string resultString = Regex.Replace(content, "<.*?>", "");
                                                    dtg_vtm.Rows[index].Cells["col_status"].Value = resultString;
                                                }
                                                else
                                                {
                                                    string displaymsg = json["status"]["displayMessage"].ToString();
                                                    dtg_vtm.Rows[index].Cells["col_status"].Value = displaymsg;
                                                }
                                                LayListVatpham_Hidden(username, imei, token, index);
                                                stop = true;
                                                break;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    dtg_vtm.Rows[index].Cells["col_status"].Value = response.ToString();
                                }
                                UpdateDatabase(username, response.ToString());
                            });
                        }
                        else
                        {
                            dtg_vtm.Rows[index].Cells["col_status"].Value = response.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        flag = true;
                        dtg_vtm.Rows[index].Cells["col_status"].Value = ex.ToString();
                    });
                }
            });
        }
        public void GetReward(string username, string imei, string token, int index, int rewardCode)
        {
            Task.Run(async () =>
            {
                try
                {
                    using (HttpRequest request = new HttpRequest())
                    {
                        await Task.Delay(delay);
                        if (proxyClient != null)
                        {
                            request.Proxy = HttpProxyClient.Parse(proxyClient);
                        }
                        request.AddHeader("Authorization", $"Bearer {token}");
                        request.AddHeader("App-Version", "6.8.10");
                        request.AddHeader("Product", "VIETTELPAY");
                        request.AddHeader("Type-Os", "ios");
                        request.AddHeader("Accept-Language", "vi");
                        request.AddHeader("Imei", $"{imei}");
                        request.AddHeader("Device-Name", "iPhone");
                        request.AddHeader("User-Agent", "Viettel Money/6.8.10 (com.viettel.viettelpay; build:1; iOS 17.0.1) Alamofire/6.8.10");
                        request.AddHeader("Os-Version", "17.0.1");
                        request.AddHeader("Authority-Party", "APP");
                        HttpResponse response = request.Get("https://api8.viettelpay.vn/customer/v1/accounts?home-version=2.0&post-check=1&recommendations=1&sources=1");
                        JToken jToken = JToken.Parse(response.ToString());
                        string ssid = jToken.SelectToken("data.otherData.sessionId")?.Value<string>();
                        if (ssid != null)
                        {
                            string payload = "{\"programCode\":\"SAM_TET_2024\",\"giftSetTypeId\":" + rewardCode + "}";
                            request.AddHeader("Accept", "application/json, text/plain, */*");
                            request.AddHeader("Sec-Fetch-Site", "same-origin");
                            request.AddHeader("Accept-Language", "vi-VN,vi;q=0.9");
                            request.AddHeader("Sec-Fetch-Mode", "cors");
                            request.AddHeader("Sessionid", ssid);
                            request.AddHeader("User-Agent", "Mozilla/5.0 (iPhone; CPU iPhone OS 17_0_1 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/15E148");
                            request.AddHeader("Referer", "https://api24cdn.vtmoney.vn/campaign/digital-kingdom-webview/home-2024/items-box?prevUrl=home-2024%2Fevent-hub");
                            request.AddHeader("Sec-Fetch-Dest", "empty");
                            response = request.Post("https://api24cdn.vtmoney.vn/game/game2021-api/public/v2/api/digital-kingdom/convert-gift-set-reward", payload, "application/json");
                            RewardResponse reward = JsonConvert.DeserializeObject<RewardResponse>(response.ToString());
                            Invoke((MethodInvoker)delegate
                            {
                                if (reward.status.code == "ERR_DK18")
                                {
                                    string msg = reward.status.message;
                                    dtg_vtm.Rows[index].Cells["col_status"].Value = msg;
                                }
                                else
                                {
                                    string tenqua = reward.data.listGiftItem[0].rewardName;
                                    dtg_vtm.Rows[index].Cells["col_status"].Value = tenqua;
                                }
                                LayListVatpham_Hidden(username, imei, token, index);
                            });
                        }
                        else
                        {
                            dtg_vtm.Rows[index].Cells["col_status"].Value = response.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        flag = true;
                        dtg_vtm.Rows[index].Cells["col_status"].Value = ex.ToString();
                    });
                }
            });
        }
        public void SelectBlacklist()
        {
            string[] listExcept = System.IO.File.ReadAllLines("Import/data.txt");
            dataTable = new DataTable();
            foreach (string username in listExcept)
            {
                string query = $"SELECT id, username, imei, session, status FROM VTMData WHERE username=@username";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                dataAdapter = new SQLiteDataAdapter(command);
                dataAdapter.Fill(dataTable);
            }
            dtg_vtm.DataSource = dataTable;
            for (int i = 0; i < dtg_vtm.Rows.Count; i++)
            {
                dtg_vtm.Rows[i].Cells["col_stt"].Value = i + 1;
            }
        }
        #endregion

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string filePath = "Import";
            Process.Start(filePath);
        }
    }
}
