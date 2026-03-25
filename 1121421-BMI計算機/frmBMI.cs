using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1121421_BMI計算機
{
    public partial class frmBMI : Form
    {
        public frmBMI()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            bool isHeightValid = Double.TryParse(this.txtHeight.Text, out double height);
            bool isWeightValid = Double.TryParse(this.txtWeight.Text, out double weight);

            if (isHeightValid) {
                if (height <= 0)
                {
                    MessageBox.Show("身高必須大於零。","身高值錯誤",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("請輸入有效的身高數值。","身高值錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (isWeightValid)
            {
                if (weight <= 0)
                {
                    MessageBox.Show("體重必須大於零。", "體重值錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("請輸入有效的體重數值。", "體重值錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            height = height / 100.0; //將身高從公分換成公尺
            double bmi = weight / (height * height);

            string[] strResultList = { "體重過輕", "健康體重", "體重過重", "輕度肥胖", "中度肥胖", "重度肥胖" };
            Color[] colorList = {Color.Blue, Color.Green, Color.Yellow , Color.Orange , Color.OrangeRed ,Color.Red};

            //顯示BMI結果
            string strResult = "";
            Color colorResult = Color.Black;
            int ResultIndex = 0;

            if (bmi < 18.5)
            {
                ResultIndex = 0;
            }
            else if(18.5 <= bmi && bmi < 24)
            {
                ResultIndex = 1;
            }
            else if(24 <= bmi && bmi < 27)
            {
                ResultIndex = 2;
            }
            else if (27 <= bmi && bmi < 30)
            {
                ResultIndex = 3;
            }
            else if (30 <= bmi && bmi < 35)
            {
                ResultIndex = 4;
            }
            else
            {
                ResultIndex = 5;

            }

                strResult = strResultList[ResultIndex];
            colorList[ResultIndex] = colorResult;

            this.lblResult.Text = $"{bmi} ({strResultList})";
            
        }

        private void lblResult_Click(object sender, EventArgs e)
        {

        }
    }
}
