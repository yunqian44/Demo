using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //  "http://aip.bdstatic.com/portal/dist/1547780921660/ai_images/technology/ocr-cards/idcard/demo-card-1.png"
            var byteArray= HttpHelper.GetResponseStream(HttpHelper.GetGetResponseEx(ImageAddress.Text));
            var image = byteArray.Base64StringToImage();
            if (image != null)
            {
                ImageBox.Image = image;
                var resultModel = IdCardValidateService.GetIdCardInfo(ImageAddress.Text);
                if (resultModel.Status == 1 && resultModel.Data != null)
                {
                    IdCardInfo model = resultModel.Data as IdCardInfo;
                    Name.Text = model.Name;
                    IdCard.Text = model.IdCard;
                    Sex.Text = model.Gender;
                    Address.Text = model.Address;
                    Birthday.Text = model.Birthday;
                    Nation.Text = model.Nation;
                }
            }
            else {
                MessageBox.Show("请输入正确的网络图片链接");
            }
        }
    }
}
