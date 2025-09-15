namespace Componentes
{
    public partial class Form1 : Form
    {
        string login = string.Empty;
        string senha = string.Empty;

        public Form1()
        {
            InitializeComponent();

        }

        public void btnAdd_Click(object sender, EventArgs e)
        {
            adicionar();
        }

        public void adicionar()
        {
            var ValidadorSenha = new ValidadorSenha();
            var ValidadorEmail = new ValidadorEmail();

            bool flag = true;
            
            lblErroLogin.Text = String.Empty;
            lblErroSenha.Text = String.Empty;

            if (string.IsNullOrEmpty(txtLogin.Text))
            {
                lblErroLogin.ForeColor = Color.Red;
                lblErroLogin.Text = "Campo obrigatório*";
                flag = false;
            }

            if (string.IsNullOrEmpty(txtSenha.Text))
            {
                lblErroSenha.ForeColor = Color.Red;
                lblErroSenha.Text = "Campo obrigatório*";
                flag = false;
            }

            if(flag)
            {
                login = txtLogin.Text;
                senha = txtSenha.Text;

                MessageBox.Show($"LOGIN: {login} \n\n SENHA: {senha}",
                    "CONCLUÍDO!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                txtLogin.Text = String.Empty;
                txtSenha.Text = String.Empty;
            }
            ValidadorSenha.SenhaValida(txtSenha.Text);
            ValidadorEmail.EmailValido(txtLogin.Text);
        }

    }
    public class ValidadorSenha
    {
        public bool SenhaValida(string senha)
        {
            return tamanhoMinimo(senha.Length)
                && temNumero(senha)
                && temMaiusculo(senha)
                && temMinusculo(senha)
                && temSimbolo(senha);
        }

        public bool tamanhoMinimo(int tamSenha)
        {
            return tamSenha >= 8;
        }

        public bool temNumero(string senha)
        {
            return senha.Any(char.IsDigit);
        }

        public bool temMaiusculo(string senha)
        {
            return senha.Any(char.IsUpper);
        }

        public bool temMinusculo(string senha)
        {
            return senha.Any(char.IsLower);
        }

        public bool temSimbolo(string senha)
        {
            return senha.Any(c => !char.IsLetterOrDigit(c));
        }
    }
    public class ValidadorEmail
    {
        public bool EmailValido(string email)
        {
            return contemArroba(email)
                && terminaComGmail(email)
                && nomeUsuarioValido(email);
        }

        public bool contemArroba(string email)
        {
            return email.Contains('@');
        }

        public bool terminaComGmail(string email)
        {
            return email.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase);
        }

        public bool nomeUsuarioValido(string email)
        {
            var partes = email.Split('@');
            return partes.Length == 2 && !string.IsNullOrWhiteSpace(partes[0]);
        }
    }
}