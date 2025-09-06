
using Actividad_practica_1_412056_1w3_Polzoni_Benjamin.Domain;
using Actividad_practica_1_412056_1w3_Polzoni_Benjamin.Services;

ArticleServices oArticleS = new ArticleServices();
ClientServices oClientS = new ClientServices();
InvoiceServices oInvoiceS = new InvoiceServices();
SellerServices oSellerS = new SellerServices();

List<Article> listArticles = oArticleS.GetAll();
List<Client> listClient = oClientS.GetAll();
List<Seller> listSeller = oSellerS.GetAll();

//foreach(Seller seller in listSeller)
//{
//    Console.WriteLine(seller.ToString);
//}
//foreach (Client client in listClient)
//{
//    Console.WriteLine(client.ToString());
//}
//foreach (Article article in listArticles)
//{
//    Console.WriteLine(article.ToString());
//}

List<DetailInvoice> listDetail = new List<DetailInvoice>()
{
    new DetailInvoice()
    {
        Article = listArticles[0],
        UnitPrice = 1000,
        Count = 2,
    },
    new DetailInvoice()
    {
        Article = listArticles[3],
        UnitPrice = 1450,
        Count = 4,
    }
};

Invoice invoice = new Invoice()
{
    Client = listClient[0],
    Seller = listSeller[0],
    DetailInvoices = listDetail,
    date = DateTime.Now,
};

bool seCargo = oInvoiceS.Save(invoice);

if (seCargo)
{
    Console.WriteLine("Se ha ingresado un valor con exito");
}