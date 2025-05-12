using System.Net;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestSoftwareDeveloperGetechnologiesMxDotnet.Models;
using TestSoftwareDeveloperGetechnologiesMxDotnet.Tools;

namespace TestSoftwareDeveloperGetechnologiesMxDotnet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private Validations validations = new Validations();
        public MainWindow()
        {
            InitializeComponent();
            SizeChanged += MainWindow_SizeChanged;
            UpdateLayoutBasedOnWidth(ActualWidth);
        }

        private async void Button_Send(object sender, RoutedEventArgs e)
        {

            Person personForm = await GetPersonFromForm();
            var validateModel = validations.ValidateModel(personForm);
            if (!validateModel.isvalid)
            {
                MessageBox.Show(validateModel.message);
                return;
            }

            string inputText = Amount.Text;
            double numericValue;
            if (!double.TryParse(inputText, out numericValue))
            {
                MessageBox.Show("Por favor, introduce un número válido", "Error de Entrada");
                Amount.Focus();
                return;
            }

            var resultPerson = await PostPersonAsync(personForm, ApiEndpoints.DirectoryEndpoint);
            var bill = await GenerateBillFromAmount(Amount.Text);
            if (bill != null)
            {
                bill.PersonId = (int)resultPerson.Data;
            }
            var resultBill = await PostBillAsync(bill, ApiEndpoints.FacturaEndpoint);
            this.Visibility = Visibility.Hidden;
            GridWindow gridwindow = new GridWindow();
            gridwindow.Visibility = Visibility.Visible;

        }

        public async Task<List<WeatherForecast>> GetAsync(string endpoint)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{ApiEndpoints.BaseUrl}/{endpoint}");
                response.EnsureSuccessStatusCode();
                string jsonString = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<WeatherForecast>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error de solicitud HTTP: {ex.Message}");
                return default;
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error al deserializar JSON: {ex.Message}");
                return default;
            }
        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateLayoutBasedOnWidth(e.NewSize.Width);
        }

        private void UpdateLayoutBasedOnWidth(double width)
        {
            if (width < 600)
            {
                Grid.SetRow(LogoImage, 0);
                Grid.SetColumn(LogoImage, 0);
                Grid.SetColumnSpan(LogoImage, 2);

                Grid.SetRow(FormPanel, 1);
                Grid.SetColumn(FormPanel, 0);
                Grid.SetColumnSpan(FormPanel, 2);

                LogoImage.HorizontalAlignment = HorizontalAlignment.Center;
                LogoImage.VerticalAlignment = VerticalAlignment.Center;
                LogoImage.Margin = new Thickness(0, 10, 0, 300); 


                FormPanel.HorizontalAlignment = HorizontalAlignment.Center;
                FormPanel.VerticalAlignment = VerticalAlignment.Center;
                FormPanel.Margin = new Thickness(0, 0, 0, 10);
            }
            else
            {
                Grid.SetRow(LogoImage, 0);
                Grid.SetColumn(LogoImage, 0);
                Grid.SetRowSpan(LogoImage, 2);
                Grid.SetColumnSpan(LogoImage, 1);

                Grid.SetRow(FormPanel, 0);
                Grid.SetColumn(FormPanel, 1);
                Grid.SetRowSpan(FormPanel, 2);
                Grid.SetColumnSpan(FormPanel, 1);

                LogoImage.HorizontalAlignment = HorizontalAlignment.Center;
                LogoImage.VerticalAlignment = VerticalAlignment.Center;
                LogoImage.Margin = new Thickness(40, 20, 40, 20);

                FormPanel.HorizontalAlignment = HorizontalAlignment.Center;
                FormPanel.VerticalAlignment = VerticalAlignment.Center;
                FormPanel.Margin = new Thickness(40, 20, 40, 20);
            }
        }

        private async Task<Person> GetPersonFromForm()
        {
            Person person = new Person() {
                Name = Name.Text,
                MiddleName = MiddleName.Text,
                LastName = LastName.Text,
                Identification = Identification.Text
            };

            return person;
        }

        public async Task<GenericResponse> PostPersonAsync(Person persona,string endpoint)
        {
            try
            {
                string jsonData = JsonSerializer.Serialize(persona);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync($"{ApiEndpoints.BaseUrl}/{endpoint}",content);
                string jsonString = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<GenericResponse>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error en la solicitud POST: {ex.Message}");
                return new GenericResponse
                {
                    Code = HttpStatusCode.InternalServerError,
                    Message = "Hubo un problema en la api",
                    Data = 0
                };
            }
        }

        public async Task<GenericResponse> PostBillAsync(Bill? bill, string endpoint)
        {
            var identificationPerson = Identification.Text;

            if (bill == null || string.IsNullOrEmpty(identificationPerson))
                return new GenericResponse
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = "Objeto vacío",
                    Data = 0
                };


            try
            {
                string jsonData = JsonSerializer.Serialize(bill);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync($"{ApiEndpoints.BaseUrl}/{endpoint}?identificationPerson={identificationPerson}", content);
                string jsonString = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<GenericResponse>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error en la solicitud POST: {ex.Message}");
                return new GenericResponse
                {
                    Code = HttpStatusCode.InternalServerError,
                    Message = "Hubo un problema en la api",
                    Data = 0
                };
            }
        }

        public async Task<Bill?> GenerateBillFromAmount(string amount)
        {
            if (string.IsNullOrEmpty(amount))
                return null;

            Bill bill = new Bill()
            {
                Amount = float.Parse(amount),
                Date = DateTime.Now
            };

            return bill;
        }
    }
}