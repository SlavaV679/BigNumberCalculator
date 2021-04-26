using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BigNumberCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnChooseFile1_Click(object sender, RoutedEventArgs e)
        {
            ReadFile(txtBoxNum1);
        }

        private void btnChooseFile2_Click(object sender, RoutedEventArgs e)
        {
            ReadFile(txtBoxNum2);
        }

        private void btnResult_Click(object sender, RoutedEventArgs e)
        {
            string num1 = txtBoxNum1.Text;
            string num2 = txtBoxNum2.Text;

            string result = "";
            int remain, carryOver = 0, sumTemp;

            int max = Math.Max(num1.Length, num2.Length);
            if (num1.Length < num2.Length)
                num1 = num1.PadLeft(max, '0');
            else
                if (num1.Length > num2.Length)
                num2 = num2.PadLeft(max, '0');

            for (int i = max - 1; i >= 0; i--)
            {
                sumTemp = carryOver + (int)char.GetNumericValue(num1[i]) + (int)char.GetNumericValue(num2[i]);
                remain = sumTemp % 10;
                result += remain.ToString();
                carryOver = sumTemp / 10;
            }

            txtBoxResult.Text = new string(result.Reverse().ToArray());
        }

        #region helperMethods

        private void ReadFile(TextBox txtBox)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                string pathFile1 = dlg.FileName;
                using (StreamReader sr = new StreamReader(pathFile1))
                {
                    txtBox.Text = sr.ReadToEnd();
                }
            }
        }

        #endregion
    }
}
