using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MercadoPago.Client.Preference;
using MercadoPago.Config;
using MercadoPago.Resource.Preference;
using Dominio;
using Newtonsoft.Json;

namespace MercadoPago
{
    //public class MercadoPagoNegocio
    //{
    //    private PreferenceRequest request;
    //    private List<PreferenceItemRequest> listaPreferenceItemRequest;
    //    private Preference preference;
    //    private PreferenceClient client;
    //    private string success;
    //    private string failure;
    //    private string pending;

    //    public Preference Preferencia
    //    {
    //        get { return preference; }

    //    }
    //    public MercadoPagoNegocio(string urlBase)
    //    {
    //       MercadoPagoConfig.AccessToken = ConfigurationManager.AppSettings["MERCADO_PAGO_TOKEN"];
    //       //MercadoPagoConfig.AccessToken = "APP_USR-7456915743267238-070916-edc3965713008b61262a4c36fe6a2d16-2543859295";
    //       string baseUrl = urlBase.TrimEnd('/').Replace("http://","https://");
    //       success = baseUrl + "/CompraConfirmadaMp.aspx";
    //       failure = baseUrl + "/PurchaseFailure.aspx";
    //       pending = baseUrl + "/PurchasePending.aspx";
    //    }

    //    public string PagarMercadoPago(Carrito producto)
    //    {
    //        try
    //        {
    //            CargarItemsPreferenceRequest(producto);
    //            CrearPreferenceRequest();

    //            client = new PreferenceClient();
    //            preference = client.Create(request);
    //            return preference.InitPoint;
    //        }
    //        catch (Exception)
    //        {

    //            throw;
    //        }
    //    }
    //    private void CrearPreferenceRequest()
    //    {
    //        string externalReference = string.Concat("Compra-", DateTime.Now);
    //        request = new PreferenceRequest
    //        {
    //            Items = listaPreferenceItemRequest,
    //            BackUrls = new PreferenceBackUrlsRequest
    //            {
    //                Success = success,
    //                Failure = failure,
    //                Pending = pending
    //            },
    //            AutoReturn = "approved",
    //            ExternalReference = externalReference
    //        };
    //    }
    //    private void CargarItemsPreferenceRequest(Carrito producto)
    //    {
    //        try
    //        {
    //            listaPreferenceItemRequest = new List<PreferenceItemRequest>();

    //            foreach (var item in producto.Items)
    //            {
    //                listaPreferenceItemRequest.Add(new PreferenceItemRequest
    //                {
    //                    Title = item.Libro?.Titulo ?? "Producto sin título",
    //                    Quantity = item.Cantidad,
    //                    UnitPrice = item.Libro?.Precio ?? 0,
    //                    CurrencyId = "ARS"
    //                });
    //            }
    //        }
    //        catch (Exception)
    //        {

    //            throw;
    //        }
    //    }
    }
}
