using Entity_SQL_SERVER.Model;

namespace EntityFrameWork_WInforms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal d = Decimal.Parse(textBox2.Text);
            AddDate(textBox1.Text, d);
        }

        /// <summary>
        /// ���������� ������ 
        /// </summary>
        /// <param name="name">���</param>
        /// <param name="price">����</param>
        private void AddDate(string name, decimal price) 
        {
            using var db = new AppDbContext();

            db.Database.EnsureCreated(); // ������� ��, ���� � ���, ��� ����� �� ������ �� ������ �������!!!   

            db.Products.Add(new Product { Name = name, Price = price });
         
            db.SaveChanges();

            // ������� ��� ��������
            string s = "";
            foreach (var product in db.Products)
            {
                s += $"{product.Id}: {product.Name} - {product.Price:C}\n";
            }
            label3.Text=s;
        }


        private void SearchProductPrive(string name) 
        {
            using var db = new AppDbContext();
            var expensiveProducts = db.Products.Where(p => p.Price > 50).ToList();
            foreach (var product in expensiveProducts)
            {
                Console.WriteLine($"{product.Name} - {product.Price:C}");
            }
        }
        private void SearchProductPrive(string name)
        {
            using var db = new AppDbContext();
            var expensiveProducts = db.Products.Where(p => p.Price > 50).ToList();
            foreach (var product in expensiveProducts)
            {
                Console.WriteLine($"{product.Name} - {product.Price:C}");
            }
        }
    }
}
