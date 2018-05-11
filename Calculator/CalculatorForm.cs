using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        private decimal memory;
        //helper numbers
        private decimal num1;
        private decimal num2;
        //<--
        private decimal value;
        private string operation;
        private StringBuilder builder;
        private int count;
        private bool operation_activated;
        private bool decimal_activated;
        private bool canPerformOperation;

        public Calculator()
        {
            InitializeComponent();
            this.num1 = int.MinValue;
            this.builder = new StringBuilder();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void HistoryBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.builder.ToString());
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            this.value = 0;
            this.num1 = int.MinValue;
            this.num2 = 0;
            this.operation = string.Empty;
            this.decimal_activated = false;
            result.Clear();
        }

        private void NumBtn_Click(object sender, EventArgs e)
        {
            //Clears Text Field after an operation button has been pressed
            if (this.operation_activated)
            {
                result.Clear();
                this.decimal_activated = false;
            }

            //Removes unnesecery '0'-s before the ','
            ValidateNumberLeadingDecimalZeros();

            var button = (Button)sender;
            result.Text += button.Text;

            //In order to type a number with more than 2 digits
            this.operation_activated = false;
        }

        private void DecimalPointBtn_Click(object sender, EventArgs e)
        {
            //Button doesn't work if pressed incorrectly
            if (result.Text.Equals(string.Empty))
            {
                return;
            }

            //Forbids the user from entering more than two decimal points
            if (!this.decimal_activated)
            {
                var button = (Button)sender;
                result.Text += button.Text;
                this.decimal_activated = true;
            }
        }

        private void MemoryBtn_Minus_Click(object sender, EventArgs e)
        {
            //Button doesn't work if pressed incorrectly
            if (result.Text.Equals(string.Empty))
            {
                return;
            }

            var num = decimal.Parse(result.Text);
            this.memory -= num;
            this.operation_activated = true;
        }

        private void MemoryBtn_Plus_Click(object sender, EventArgs e)
        {
            //Button doesn't work if pressed incorrectly
            if (result.Text.Equals(string.Empty))
            {
                return;
            }

            var num = decimal.Parse(result.Text);
            this.memory += num;
            this.operation_activated = true;
        }

        private void MemoryBtn_C_Click(object sender, EventArgs e)
        {
            this.memory = 0;
        }

        private void MemoryBtn_R_Click(object sender, EventArgs e)
        {
            result.Text = this.memory.ToString();
            this.operation_activated = true;
        }

        private void Operator_Click(object sender, EventArgs e)
        {
            //Button doesn't work if pressed incorrectly
            if (result.Text.Equals(string.Empty))
            {
                return;
            }

            //Only used when the Clear_Btn has been pressed or when the user types in the first number
            if (this.num1.Equals(int.MinValue))
            {
                this.num1 = decimal.Parse(result.Text);
                ValidateDecimalZeros_Num1();
                this.builder.Append(++this.count + ") " + this.num1);
            }

            //Ensures that the program continues to work after the Equals_Btn has been pressed
            else if (this.canPerformOperation)
            {
                CalculateSum();
            }

            this.canPerformOperation = true;
            var button = (Button)sender;
            this.operation = button.Text;
            this.operation_activated = true;
        }

        private void PercentBtn_Click(object sender, EventArgs e)
        {
            if (num1.Equals(int.MinValue))
            {
                return;
            }

            this.num2 = decimal.Parse(result.Text);
            var temp = this.num2;
            this.num2 = temp / 100 * this.num1;
            result.Text = this.num2.ToString();
            CalculateSum();
        }

        private void EqualsBtn_Click(object sender, EventArgs e)
        {
            //Ensure that Equals_Btn doesn't work if pressed incorreclty
            if (num1.Equals(int.MinValue))
            {
                return;
            }

            CalculateSum();
            this.builder.AppendLine(Environment.NewLine + "=");
            this.builder.AppendLine(Math.Round(this.value, 7).ToString());
        }

        private void CalculateSum()
        {
            this.num2 = decimal.Parse(result.Text);
            ValidateDecimalZeros_Num2();
            this.builder.Append(this.operation + this.num2);

            switch (this.operation)
            {
                case "+":
                    this.value = num1 + num2;
                    break;
                case "-":
                    this.value = num1 - num2;
                    break;
                case "/":
                    this.value = num1 / num2;
                    break;
                case "*":
                    this.value = num1 * num2;
                    break;
                case "%":
                    this.value = num1 % num2;
                    break;
            }

            //Assign num1 to tha last result.Text, which is also this.value
            this.num1 = value;

            this.canPerformOperation = false;

            PrintToScreen();
        }

        private void ValidateDecimalZeros_Num1()
        {
            var number = this.num1.ToString();

            ValidateNumber(number);

            this.num1 = decimal.Parse(result.Text);
        }

        private void ValidateDecimalZeros_Num2()
        {
            var number = this.num2.ToString();

            ValidateNumber(number);

            this.num2 = decimal.Parse(result.Text);
        }

        //removes unnecessary '0'-s after the decimal point, if there are any
        private void ValidateNumber(string number)
        {
            if (!number.Contains(','))
            {
                return;
            }

            var tokens = number.Split(',');

            var lastIndexOfNum = Array.FindLastIndex(tokens[1].ToCharArray(), item => item != '0');

            //Is activated only when the number has only '0'-s after the decimal point 
            if (lastIndexOfNum.Equals(-1))
            {
                result.Text = tokens[0];
                return;
            }
            //Is activated when the decimal part of the num is in the correct format and needs no modification
            else if (lastIndexOfNum.Equals(tokens[1].Length - 1))
            {
                return;
            }

            var tail = tokens[1].Substring(lastIndexOfNum);

            if (tail.Skip(1).All(n => n.Equals('0')))
            {
                var finalOutputNum = result.Text.Remove(result.Text.Length - tail.Length + 1);
                result.Text = finalOutputNum;
            }
        }

        //removes unnecessary '0'-s before the decimal point, if there are any
        private void ValidateNumberLeadingDecimalZeros()
        {
            if (this.decimal_activated)
            {
                var text = result.Text;
                var index = text.IndexOf(',');
                var front = text.Substring(0, index);

                if (front.All(n => n.Equals('0')))
                {
                    result.Text = "0" + text.Substring(index);
                }
            }
        }

        private void PrintToScreen()
        {
            var returnResult = Math.Round(this.value, 7).ToString();

            if (returnResult.Contains(','))
            {
                var index = returnResult.IndexOf(',');
                var tail = returnResult.Substring(index);

                //If the result ends with ",0" it removes the last two symbols
                if (returnResult.EndsWith("," + new string('0', tail.Length - 1)))
                {
                    returnResult = returnResult.Remove(index);
                }
            }
            result.Text = returnResult;
        }
    }
}