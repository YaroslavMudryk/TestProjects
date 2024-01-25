using System.Text.Json;
using System.Text.Json.Nodes;
using TestProjects.ImeiCheck.Models;

namespace TestProjects.ImeiCheck
{
    public partial class MainPage : ContentPage
    {
        private readonly HttpClient _httpClient;
        private Service _selectedService = null;
        public MainPage()
        {
            InitializeComponent();

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.imeicheck.net/")
            };
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer eRhbaxh7s9Os07DH0iBCfQNFQ5J539HLXlUyMG9ia75f8096");

        }

        protected override void OnAppearing()
        {
            UpdateBalance();
            LoadServices();
            base.OnAppearing();
        }


        private async void UpdateBalance()
        {
            var response = await _httpClient.GetAsync("v1/account");

            var jsonContent = await response.Content.ReadAsStringAsync();

            var account = JsonSerializer.Deserialize<Account>(jsonContent);

            balance.Text = $"Ваш баланс: {account.Balance} $";
        }

        private async void LoadServices()
        {
            var response = await _httpClient.GetAsync("v1/services");

            var jsonContent = await response.Content.ReadAsStringAsync();

            var services = JsonSerializer.Deserialize<List<Service>>(jsonContent);

            servicePicker.ItemsSource = services;
        }

        private async void LoadDetailsByImeiOrSerialNumber()
        {
            if (_selectedService == null || _selectedService.Id == 0)
            {
                await DisplayAlert("Помилка", "Оберіть тип сервісу", "OK");
                return;
            }

            var deviceId = deviceIdEntry.Text;

            if (string.IsNullOrEmpty(deviceId))
            {
                await DisplayAlert("Помилка", "Введіть IMEI або серійний номер пристрою", "OK");
                return;
            }

            deviceId = deviceId.Trim();

            //var jsonPostContent = JsonContent.Create(new { serviceId = _selectedService.Id, deviceId = deviceId });
            //var response = await _httpClient.PostAsync("v1/checks", jsonPostContent);
            //var jsonContent = await response.Content.ReadAsStringAsync();
            //var device = JsonSerializer.Deserialize<Check<SamsungDetails>>(jsonContent);

            var response = await _httpClient.GetAsync("v1/checks");

            var jsonContent = await response.Content.ReadAsStringAsync();

            var checks = JsonObject.Parse(jsonContent);

            var a = checks.AsArray();

            var b = a.Last();

            var c = b.ToJsonString();

            var device = JsonSerializer.Deserialize<Check<SamsungDetails>>(c);

            if (device.Status == "successful")
            {
                Init(device.Details);
            }
        }

        private void servicePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedService = (sender as Picker).SelectedItem as Service;
        }

        private void checkImei_Clicked(object sender, EventArgs e)
        {
            LoadDetailsByImeiOrSerialNumber();
        }

        public void Init(SamsungDetails samsungDetails)
        {
            Imei2.Text = samsungDetails.Imei2;
            Serial.Text = samsungDetails.SerialNumber;
            DoNumber.Text = samsungDetails.DoNumber;
            Manufacturer.Text = samsungDetails.Manufacturer;
            FullName.Text = samsungDetails.FullName;
            ModelNumber.Text = samsungDetails.ModelNumber;
            ModelName.Text = samsungDetails.ModelName;
            ProductionDate.Text = samsungDetails.ProductionDate.ToLongDateString();
            WarrantyUntil.Text = samsungDetails.WarrantyUntil.ToLongDateString();
            WarrantyStatus.Text = samsungDetails.WarrantyStatus;
            Carrier.Text = samsungDetails.Carrier;
            SoldByCountry.Text = samsungDetails.SoldByCountry;
            ShipToCountry.Text = samsungDetails.ShipToCountry;
            SoldDate.Text = samsungDetails.SoldDate.ToLongDateString();
            ShipDate.Text = samsungDetails.ShipDate.ToLongDateString();
            Imei.Text = samsungDetails.Imei;
        }
    }
}
