namespace bar
{
    public partial class Form1 : Form
    {
        List<float> values = new List<float>();
        List<string> labels = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            values.Clear();
            labels.Clear();
            string inputval = txtValues.Text;
            string inputlab = txtlabels.Text;
            if (string.IsNullOrWhiteSpace(inputval))
            {
                MessageBox.Show("Enter Aleast The values to make graph", "Error");
            }
            else
            {


                string[] stringLab = inputlab.Split(',');
                string[] stringL = inputval.Split(",");
                int[] inpvalues = Array.ConvertAll(stringL, int.Parse);
                if (stringLab.Length != inpvalues.Length ) {
                    if (stringLab.Length > inpvalues.Length)
                    {
                        MessageBox.Show("Enter all the values for labels.");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Enter all the labels for Values.");
                        return;
                    }
                }
                if (string.IsNullOrWhiteSpace(inputlab))
                {
                    for (int i = 0; i < inpvalues.Length; i++)
                    {
                        char letter = (char)('A' + i);
                        string l = letter.ToString();
                        labels.Add(l);
                    }
                }
                else
                {
                    foreach (string v in stringLab)
                    {
                        labels.Add(v);
                    }
                }
                foreach (int v in inpvalues)
                {
                    values.Add(v);
                }
            }

            bar1.set(values, labels);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
