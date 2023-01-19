using MySql.Data.MySqlClient;
namespace pracitca1
{
    public partial class Form1 : Form
    {
        String connString = "datasource=127.0.0.1;port=3306;username=root;password=;database=pueblacapital;";
        MySqlConnection conn;
        public Form1()
        {
            InitializeComponent();
            conn= new MySqlConnection(connString);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn.Open();
            //String sql = "SELECT * FROM `pueblacapital` WHERE texto LIKE '%tel%'";
            String sql = "SELECT SUBSTRING(texto, 1, 22) AS ExtractString FROM pueblacapital WHERE texto LIKE '%Tipo:%'";
            String sql = "SELECT SUBSTRING(texto, LOCATE('incidente',texto), 16) AS ExtractString FROM pueblacapital;";
            MySqlCommand comm= new MySqlCommand(sql, conn);
            MySqlDataReader dr = comm.ExecuteReader();
            String line = "";
            
            while (dr.Read())
            {
                //line += dr.GetString(1)+"\n";
                line += dr.GetString(0)+"\n\n";
            }
            richTextBox1.Text = line;
        }
    }
}
