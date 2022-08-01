using System;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Net;

namespace osu__charindsNetwork_Switcher
{
    public partial class Form1 : Form
    {

        private Encoding enc;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            remove_hosts_data();
            bool r = true;
            if (checkBox1.Checked) 
            {
                bool result = add_hosts_data();
                if (!result)
                {
                    r = false;
                }
            }

            if (r)
            {
                MessageBox.Show("サーバーの変更に成功しました。\r\nosuを再起動してください", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private bool add_hosts_data()
        {
            enc = Encoding.GetEncoding("UTF-8");
            string path = @"c:/Windows/System32/drivers/etc/hosts";

            if (!System.IO.File.Exists(path))
            {
                FileInfo fileInfo = new FileInfo(path);
                FileStream fileStream = fileInfo.Create();
                fileStream.Close();
            }

            //ファイルの内容を読み込む
            StreamReader sr = new StreamReader(path, Encoding.GetEncoding("Shift_JIS"));

            //内容をすべて読み込む
            string s = sr.ReadToEnd();

            //閉じる
            sr.Close();

            // 文字列置換
            string host = serverIp.Text;
            IPAddress ipaddr;
            bool ret = IPAddress.TryParse(host, out ipaddr);
            if (!ret)
            {
                MessageBox.Show("有効なIPアドレスを入力してください", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            s += "\r\n" + host + " osu.ppy.sh";
            s += "\r\n" + host + " c.ppy.sh";
            s += "\r\n" + host + " c1.ppy.sh";
            s += "\r\n" + host + " c2.ppy.sh";
            s += "\r\n" + host + " c3.ppy.sh";
            s += "\r\n" + host + " c4.ppy.sh";
            s += "\r\n" + host + " c5.ppy.sh";
            s += "\r\n" + host + " c6.ppy.sh";
            s += "\r\n" + host + " ce.ppy.sh";
            s += "\r\n" + host + " a.ppy.sh";
            s += "\r\n" + host + " i.ppy.sh";
            s += "\r\n" + host + " i-need-to.click";
            s += "\r\n" + host + " c.i-need-to.click";
            s += "\r\n" + host + " i.i-need-to.click";
            s += "\r\n" + host + " a.i-need-to.click";
            s += "\r\n" + host + " old.i-need-to.click";

            //Shift JISで書き込む
            //書き込むファイルが既に存在している場合は、上書きする
            StreamWriter sw = new StreamWriter(
                path,
                false,
                Encoding.GetEncoding("Shift_JIS"));
            //TextBox1.Textの内容を書き込む
            sw.Write(s);
            //閉じる
            sw.Close();
            return true;
        }

        private void remove_hosts_data()
        {
            enc = Encoding.GetEncoding("UTF-8");
            string path = @"c:/Windows/System32/drivers/etc/hosts";

            if (!System.IO.File.Exists(path))
            {
                FileInfo fileInfo = new FileInfo(path);
                FileStream fileStream = fileInfo.Create();
                fileStream.Close();
            }

            StreamReader sr = new StreamReader(path, Encoding.GetEncoding("Shift_JIS"));
            //内容をすべて読み込む
            string s = sr.ReadToEnd();

            //閉じる
            sr.Close();

            // 文字列置換
            /*
            string host = "160.251.72.25";
            s = s.Replace("\r\n"+host+" osu.ppy.sh", "");
            s = s.Replace("\r\n"+host+" c.ppy.sh", "");
            s = s.Replace("\r\n"+host+" c1.ppy.sh", "");
            s = s.Replace("\r\n"+host+" c2.ppy.sh", "");
            s = s.Replace("\r\n"+host+" c3.ppy.sh", "");
            s = s.Replace("\r\n"+host+" c4.ppy.sh", "");
            s = s.Replace("\r\n"+host+" c5.ppy.sh", "");
            s = s.Replace("\r\n"+host+" c6.ppy.sh", "");
            s = s.Replace("\r\n"+host+" ce.ppy.sh", "");
            s = s.Replace("\r\n"+host+" a.ppy.sh", "");
            s = s.Replace("\r\n"+host+" i.ppy.sh", "");
            s = s.Replace("\r\n" + host + " i-need-to.click", "");
            s = s.Replace("\r\n" + host + " c.i-need-to.click", "");
            s = s.Replace("\r\n" + host + " i.i-need-to.click", "");
            s = s.Replace("\r\n" + host + " a.i-need-to.click", "");
            s = s.Replace("\r\n" + host + " old.i-need-to.click", "");
            */

            //Shift JISで書き込む
            //書き込むファイルが既に存在している場合は、上書きする
            StreamWriter sw = new StreamWriter(
                path,
                false,
                Encoding.GetEncoding("Shift_JIS"));
            //TextBox1.Textの内容を書き込む
            sw.Write("");
            //閉じる
            sw.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            serverIp.Text = "113.144.214.47";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
