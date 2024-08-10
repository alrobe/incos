namespace Hipotenusa
{
    public partial class Form1 : Form
    {
        static double catA, catB;
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            GetNumbers();
        }

        private void GetNumbers()
        {
            catA = double.Parse(textBoxCatA.Text);
            catB = double.Parse(textBoxCatB.Text);
            double res = Calculate();
            labelRes.Text = res.ToString();
        }

        private double Calculate()
        {
            return Math.Sqrt(Math.Pow(catA, 2) +  Math.Pow(catB, 2));
        }
    }
}
