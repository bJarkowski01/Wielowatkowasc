namespace Wielowatkowasc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Matrix matrix1 = new Matrix(2);
            Matrix matrix2 = new Matrix(1);
            Matrix matrix3 = new Matrix(1);
            int n = int.Parse(textBox5.Text);
            Thread[] threads = new Thread[n];

            for (int i = 0; i < n; i++)
            {
                int numer = i;
                threads[i] = new Thread(() => Matrix.Mnozenie(matrix1, matrix2, matrix3, n, numer));
            }
            
            var watch = System.Diagnostics.Stopwatch.StartNew();
            foreach (Thread x in threads) x.Start();
            foreach (Thread x in threads) x.Join();

            watch.Stop();

            textBox1.Text = matrix1.ToString();
            textBox2.Text = matrix2.ToString();
            textBox3.Text = matrix3.ToString();
            textBox4.Text = $"{n} threads ended in {watch.ElapsedMilliseconds} ms.";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Matrix matrix1 = new Matrix(2);
            Matrix matrix2 = new Matrix(1);
            Matrix matrix3 = new Matrix(1);
            int n = int.Parse(textBox5.Text);

            var watch = System.Diagnostics.Stopwatch.StartNew();

            Parallel.For(0, n, numer =>
            {
                Matrix.Mnozenie(matrix1, matrix2, matrix3, n, numer);
            });

            watch.Stop();

            textBox1.Text = matrix1.ToString();
            textBox2.Text = matrix2.ToString();
            textBox3.Text = matrix3.ToString();
            textBox4.Text = $"{n} threads ended in {watch.ElapsedMilliseconds} ms.";
        }
    }
}
