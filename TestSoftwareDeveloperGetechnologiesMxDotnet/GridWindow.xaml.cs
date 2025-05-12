using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TestSoftwareDeveloperGetechnologiesMxDotnet.Models;

namespace TestSoftwareDeveloperGetechnologiesMxDotnet
{
    /// <summary>
    /// Lógica de interacción para GridWindow.xaml
    /// </summary>
    /// 

    public partial class GridWindow : Window
    {
        public ObservableCollection<DTOPerson> MiColeccionDeDatos { get; set; }
        private static readonly HttpClient _httpClient = new HttpClient();

        public GridWindow()
        {
            InitializeComponent();
            MiColeccionDeDatos = new ObservableCollection<DTOPerson>();
            DataContext = this;
            ShowData();
        }

        public async void ShowData()
        {
            var persons = await GetPersonAsync(ApiEndpoints.DirectoryEndpoint);
            foreach (var person in persons)
            {
                DTOPerson dTOPerson = new DTOPerson
                {
                    Id = person.Id,
                    Name = $"{person.Name} {person.MiddleName} {person.LastName}",
                    Identification = person.Identification,
                    Amount = person.Bills.Count > 0 ? person?.Bills?.Sum(x => x.Amount) : 0,
                    BillsCount = person.Bills.Count > 0 ? person?.Bills?.Count() : 0,
                    LastBillDate = person.Bills.Count > 0 ? person?.Bills?.Last()?.Date : null
                };
                MiColeccionDeDatos.Add(dTOPerson);
            }
        }



        public async Task<List<Person>> GetPersonAsync(string endpoint)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{ApiEndpoints.BaseUrl}/{endpoint}");
                response.EnsureSuccessStatusCode();
                string jsonString = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Person>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
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

        public async Task<List<Bill>> GetBillsAsync(string endpoint)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{ApiEndpoints.BaseUrl}/{endpoint}");
                response.EnsureSuccessStatusCode();
                string jsonString = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Bill>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
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

        private async void EliminarPersona_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button boton && boton.CommandParameter is DTOPerson persona)
            {
               var persondto = persona as DTOPerson;
                var result = await DeletePersonAsync(persondto.Identification, ApiEndpoints.DirectoryEndpoint);
                if (result.Code == HttpStatusCode.OK)
                {
                    MiColeccionDeDatos.Remove(persondto);
                }
                else
                {
                    MessageBox.Show(result.Message);
                }
            }
        }

        public async Task<GenericResponse> DeletePersonAsync(string identification, string endpoint)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync($"{ApiEndpoints.BaseUrl}/{endpoint}?identification={identification}");
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

        private async void Regresar_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button boton && boton.CommandParameter is DTOPerson persona)
            {
                this.Visibility = Visibility.Hidden;
                MainWindow mainWindow = new MainWindow();
                mainWindow.Visibility = Visibility.Visible;
            }
        }


    }
}
