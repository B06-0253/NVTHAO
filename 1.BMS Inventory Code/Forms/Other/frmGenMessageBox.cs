using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using BMS.Business;
using BMS.Model;
using BMS.Facade;
using BMS.Utils;
namespace BMS
{
    public partial class frmGenMessageBox : Form
    {
        #region Khai báo các biến dùng chung
        string MessageCode = "";
        string FormName = "";
        string EventName = "";
        string UserMessage="";
        string SystemMessage = "";
        string Caption="";
        MessageBoxIcon Icon;
        #endregion

        #region Load Form

        public frmGenMessageBox(string messageCode,string formName,string eventName,string caption,string userMessage,string systemMessage,MessageBoxIcon icon)
        {
            InitializeComponent();
            MessageCode=messageCode;
            FormName = formName;
            EventName = eventName;
            Caption = caption;
            UserMessage = userMessage;
            SystemMessage = systemMessage;
            Icon = icon;
        }

        private void frmGenMessageBox_Load(object sender, EventArgs e)
        {
            this.Text = Caption;
            if (Icon == MessageBoxIcon.Error)
                picIcon.BackgroundImage = Bitmap.FromHicon(SystemIcons.Error.Handle);
            else if (Icon == MessageBoxIcon.Information)
                picIcon.BackgroundImage = Bitmap.FromHicon(SystemIcons.Information.Handle);
            else if (Icon == MessageBoxIcon.Question)
                picIcon.BackgroundImage = Bitmap.FromHicon(SystemIcons.Question.Handle);
            else if (Icon == MessageBoxIcon.Warning)
                picIcon.BackgroundImage = Bitmap.FromHicon(SystemIcons.Warning.Handle);
            else if (Icon == MessageBoxIcon.Exclamation)
                picIcon.BackgroundImage = Bitmap.FromHicon(SystemIcons.Exclamation.Handle);
            else if (Icon == MessageBoxIcon.Hand)
                picIcon.BackgroundImage = Bitmap.FromHicon(SystemIcons.Hand.Handle);
            else if (Icon == MessageBoxIcon.Asterisk)
                picIcon.BackgroundImage = Bitmap.FromHicon(SystemIcons.Asterisk.Handle);
            lblUserMessage.Text = UserMessage;
            txtSysMessage.Text = SystemMessage;
        }

        #endregion

        #region Các chức năng cơ bản

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                #region Khai báo Model và gán giá trị

                EventsLogErrorModel mELE = new EventsLogErrorModel();
                mELE.MessageCode = MessageCode;
                mELE.ComputerName = TextUtils.GetHostName();
                mELE.ErrorDate = TextUtils.GetSystemDate();
                mELE.EventName = EventName;
                mELE.FormName = FormName;
                mELE.ErrorContent = SystemMessage;
                EventsLogErrorBO.Instance.Insert(mELE);

                #endregion
            }
            catch
            {
                return;
            }
            finally {
                this.Close();
            }
        }

        #endregion

        #region Các sự kiện trên Form

        private void picDetail_Click(object sender, EventArgs e)
        {
            if (this.Size.Height == 350)
            {
                this.Size = new Size(300, 150);
            }
            else
                this.Size = new Size(300, 350);
        }

        #endregion

        #region Các hàm viết thêm
        #endregion
    }
}