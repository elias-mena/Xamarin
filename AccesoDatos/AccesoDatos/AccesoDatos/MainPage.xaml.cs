using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AccesoDatos.Models;
using System.Xml.Serialization;
using System.Net;
using System.IO;
using System.Globalization;
namespace AccesoDatos
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            GetExrate();
        }
        private void GetExrate()
        {
            //link xml del banco
            string url = "https://portal.vietcombank.com.vn/Usercontrols/TVPortal.TyGia/pXML.aspx?b=68";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            //obtener Respuesta
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //Llamada GetResponseStream para retornar flujo
            Stream responseStream = response.GetResponseStream();
            //Convertir XML en el modelo C#
            XmlSerializer serializer = new XmlSerializer(typeof(ExrateList));
            ExrateList exrateList = (ExrateList)serializer.Deserialize(responseStream);
            LabelDate.Text = "Date: " + exrateList.DateTime;
            //AUD
            LabelAUDBuy.Text = exrateList.Exrates[0].Buy;
            LabelAUDSell.Text = exrateList.Exrates[0].Sell;
            //CAD
            LabelCADBuy.Text = exrateList.Exrates[1].Buy;
            LabelCADSell.Text = exrateList.Exrates[1].Sell;
        }
    }
}
