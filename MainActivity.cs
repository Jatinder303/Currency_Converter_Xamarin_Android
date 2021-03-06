using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using Android.Views;
using System;

namespace Currency_Converter_Xamarin_Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Spinner spFromCurrency;
        Spinner spToCurrency;
        EditText txtFromAmount;
        EditText txtToAmount;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            txtFromAmount = FindViewById<EditText>(Resource.Id.txtFromAmount);
            txtToAmount = FindViewById<EditText>(Resource.Id.txtToAmount);
            spFromCurrency = FindViewById<Spinner>(Resource.Id.spFromCurrency);
            spToCurrency = FindViewById<Spinner>(Resource.Id.spToCurrency);

            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.Currency, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            spFromCurrency.Adapter = adapter;
            spToCurrency.Adapter = adapter;

            // Adding event handlers 
            spFromCurrency.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spFromCurrency_ItemSelected);
            spToCurrency.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spToCurrency_ItemSelected);
        }
        public void spFromCurrency_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {

        }

        public void spToCurrency_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            if (spFromCurrency.SelectedItem.ToString() == "NZD" && spToCurrency.SelectedItem.ToString() == "AUD")
            {
                txtToAmount.Text = Convert.ToString(Convert.ToDouble(txtFromAmount.Text) * 0.93);
            }
            else if (spFromCurrency.SelectedItem.ToString() == "NZD" && spToCurrency.SelectedItem.ToString() == "USD")
            {
                txtToAmount.Text = Convert.ToString(Convert.ToDouble(txtFromAmount.Text) * 0.74);
            }
            else if (spFromCurrency.SelectedItem.ToString() == "AUD" && spToCurrency.SelectedItem.ToString() == "NZD")
            {
                txtToAmount.Text = Convert.ToString(Convert.ToDouble(txtFromAmount.Text) * 1.05);
            }
            else if (spFromCurrency.SelectedItem.ToString() == "AUD" && spToCurrency.SelectedItem.ToString() == "USD")
            {
                txtToAmount.Text = Convert.ToString(Convert.ToDouble(txtFromAmount.Text) * 0.74);
            }
            else if (spFromCurrency.SelectedItem.ToString() == "USD" && spToCurrency.SelectedItem.ToString() == "NZD")
            {
                txtToAmount.Text = Convert.ToString(Convert.ToDouble(txtFromAmount.Text) * 1.43);
            }
            else if (spFromCurrency.SelectedItem.ToString() == "USD" && spToCurrency.SelectedItem.ToString() == "AUD")
            {
                txtToAmount.Text = Convert.ToString(Convert.ToDouble(txtFromAmount.Text) * 1.36);
            }
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}