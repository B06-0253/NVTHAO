using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;


namespace BMS
{
    public partial class frmEncrypt : _Forms
    {
        bool _connected = false;
        bool _encrypt = false;

        public frmEncrypt()
        {
            InitializeComponent();
        }

        /// <summary>
        /// To encrypt the input password
        /// </summary>
        /// <param name="txtPassword"></param>
        /// <returns>It returns encrypted code</returns>
        public static string EncryptPassword(string txtPassword)
        {
            byte[] passBytes = System.Text.Encoding.Unicode.GetBytes(txtPassword);
            string encryptPassword = Convert.ToBase64String(passBytes);
            return encryptPassword;
        }

        /// <summary>
        /// To Decrypt password
        /// </summary>
        /// <param name="encryptedPassword"></param>
        /// <returns>It returns plain password</returns>
        public static string DecryptPassword(string encryptedPassword)
        {
            byte[] passByteData = Convert.FromBase64String(encryptedPassword);
            string originalPassword = System.Text.Encoding.Unicode.GetString(passByteData);
            return originalPassword;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            if (ofd.ShowDialog()==DialogResult.OK)
            {
                _connected = false;
                _encrypt = true;
                txtPath.Text = ofd.FileName;
                
                string strPath = txtPath.Text.Trim();
                string[] Infor = new string[4];//0:server,1:Database;2:User,3:Pass
                FileStream file = new FileStream(strPath, FileMode.OpenOrCreate, FileAccess.Read);
                StreamReader sr = new StreamReader(file);
                int i = 0;
                while (i < 4)
                {
                    Infor[i] = sr.ReadLine();
                    i = i + 1;
                }

                txtServer.Text = Infor[0];
                txtDatabase.Text = Infor[1];
                txtUsername.Text = Infor[2];
                txtPass.Text = Infor[3];

                sr.Close();
                file.Close();
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};",
                txtServer.Text.Trim(), txtDatabase.Text, txtUsername.Text, txtPass.Text));
            try
            {
                conn.Open();
                _connected = true;
                MessageBox.Show("Kết nối cơ sở dữ liệu thành công!");
            }
            catch 
            {
                _connected = false;
                MessageBox.Show("Không kết nối được với cơ sở dữ liệu!");
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (!_encrypt)
            {
                txtPass.Text = EncryptPassword(txtPass.Text);
                txtDatabase.Text = EncryptPassword(txtDatabase.Text);
                txtServer.Text = EncryptPassword(txtServer.Text);
                txtUsername.Text = EncryptPassword(txtUsername.Text);
                _encrypt = true;
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (_encrypt)
            {
                txtPass.Text = DecryptPassword(txtPass.Text);
                txtDatabase.Text = DecryptPassword(txtDatabase.Text);
                txtServer.Text = DecryptPassword(txtServer.Text);
                txtUsername.Text = DecryptPassword(txtUsername.Text);
                _encrypt = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_connected)
            {
                MessageBox.Show("Không thể lưu trữ khi không kết nối được với csdl!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!_encrypt)
            {
                MessageBox.Show("Không thể lưu trữ khi chưa mã hóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string[] lines = { txtServer.Text, txtDatabase.Text, txtUsername.Text, txtPass.Text };
            
            using (StreamWriter file = new StreamWriter(txtPath.Text.Trim()))
            {
                foreach (string line in lines)
                {
                    file.WriteLine(line);
                }
            }

            MessageBox.Show("Lưu trữ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
