using System.Drawing.Imaging;

namespace Comparador_De_Imagens
{
    public partial class Form1 : Form
    {
        Bitmap bitmap1, bitmap2;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openflg = new OpenFileDialog();
            if (openflg.ShowDialog() == DialogResult.OK)
            {                
                pictureBox1.ImageLocation = openflg.FileName;
                bitmap1 = new Bitmap(openflg.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openflg = new OpenFileDialog();
            if (openflg.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.ImageLocation = openflg.FileName;
                bitmap2 = new Bitmap(openflg.FileName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool compare = ImageCompareString(bitmap1, bitmap2);
            if(compare == true)
            {
                MessageBox.Show("As imagens são iguais!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("As imagens NÃO são iguais!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ImageCompareString(Bitmap bitmap11, Bitmap bitmap21)
        {
            //throw new NotImplementedException();
            MemoryStream stream = new MemoryStream();
            bitmap11.Save(stream, ImageFormat.Png);
            string firstbitmap = Convert.ToBase64String(stream.ToArray());
            stream.Position = 0;
            bitmap21.Save(stream, ImageFormat.Png);
            string secondbitmap = Convert.ToBase64String(stream.ToArray());
            if (firstbitmap.Equals(secondbitmap))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}