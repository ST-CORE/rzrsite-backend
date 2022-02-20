using Newtonsoft.Json;
using RzrSite.Admin.Helper;
using RzrSite.Admin.Repositories.Interfaces;
using RzrSite.Models.Entities;
using RzrSite.Models.Resources.DbFile;
using RzrSite.Models.Resources.Documents;
using RzrSite.Models.Resources.ProductLine;
using RzrSite.Models.Responses.ProductLine;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RzrSite.Admin.Repositories
{
  public class ProductLineRepository : IProductLineRepository
  {
	private readonly HttpClient _client = new HttpClient();

	public async Task<AddedProductLine> AddProductLine(int categoryId, PostProductLine postProductLine)
	{
	  var stringifiedObject = JsonConvert.SerializeObject(postProductLine);
	  var response = await _client.PostAsync($"{UrlLocator.ApiUrl}/category/{categoryId}/productline", new StringContent(stringifiedObject, Encoding.Default, "application/json"));
	  if (response.IsSuccessStatusCode)
	  {
		var resultString = await response.Content.ReadAsStringAsync();
		return JsonConvert.DeserializeObject<AddedProductLine>(resultString);
	  }

	  return null;
	}

	public async Task<FullProductLine> GetProductLine(int categoryId, int productLineId)
	{
	  var response = await _client.GetAsync($"{UrlLocator.ApiUrl}/category/{categoryId}/productline/{productLineId}");
	  if (response.IsSuccessStatusCode)
	  {
		var resultString = await response.Content.ReadAsStringAsync();
		return JsonConvert.DeserializeObject<FullProductLine>(resultString);
	  }

	  return null;
	}

	public async Task<StrippedDbFile> GetFeaturesPdf(int categoryId, int productLineId)
	{
	  var response = await _client.GetAsync($"{UrlLocator.ApiUrl}/category/{categoryId}/productline/{productLineId}/featurespdf");
	  if (response.IsSuccessStatusCode)
	  {
		var resultString = await response.Content.ReadAsStringAsync();
		return JsonConvert.DeserializeObject<StrippedDbFile>(resultString);
	  }

	  return null;
	}

	public async Task<IList<StrippedProductLine>> GetProductLines(int categoryId)
	{
	  var response = await _client.GetAsync($"{UrlLocator.ApiUrl}/category/{categoryId}/productline");
	  if (response.IsSuccessStatusCode)
	  {
		var resultString = await response.Content.ReadAsStringAsync();
		return JsonConvert.DeserializeObject<IList<StrippedProductLine>>(resultString);
	  }

	  return null;
	}

	public async Task<IList<ProductLineDocument>> GetProductLineDocuments(int categoryId, int productLineId)
	{
	  var response = await _client.GetAsync($"{UrlLocator.ApiUrl}/category/{categoryId}/productline/{productLineId}/documents");
	  if (response.IsSuccessStatusCode)
	  {
		var resultString = await response.Content.ReadAsStringAsync();
		return JsonConvert.DeserializeObject<IList<ProductLineDocument>>(resultString);
	  }

	  return null;
	}

	public async Task<bool> RemoveProductLine(int categoryId, int id)
	{
	  var response = await _client.DeleteAsync($"{UrlLocator.ApiUrl}/category/{categoryId}/productline/{id}");
	  if (response.IsSuccessStatusCode)
	  {
		return true;
	  }

	  return false;
	}

	public async Task<StrippedProductLine> UpdateProductLine(int categoryId, int id, PutProductLine putProductLine)
	{
	  var stringifiedObject = JsonConvert.SerializeObject(putProductLine);
	  var response = await _client.PutAsync($"{UrlLocator.ApiUrl}/category/{categoryId}/productline/{id}", new StringContent(stringifiedObject, Encoding.Default, "application/json"));
	  if (response.IsSuccessStatusCode)
	  {
		var resultString = await response.Content.ReadAsStringAsync();
		return JsonConvert.DeserializeObject<StrippedProductLine>(resultString);
	  }

	  return null;
	}

	public async Task<Document> GetDocument(int id)
	{
	  var response = await _client.GetAsync($"{UrlLocator.ApiUrl}/document/get/{id}");
	  if (!response.IsSuccessStatusCode) return null;
	  var resultString = await response.Content.ReadAsStringAsync();
	  return JsonConvert.DeserializeObject<Document>(resultString);
	}

	public async Task<bool> AddDocument(PostDocument model)
	{
	  var stringifiedObject = JsonConvert.SerializeObject(model);
	  var response = await _client.PostAsync($"{UrlLocator.ApiUrl}/document/add", new StringContent(stringifiedObject, Encoding.Default, "application/json"));
	  return response.IsSuccessStatusCode;
	}

	public async Task<bool> EditDocument(PutDocument model)
	{
	  var stringifiedObject = JsonConvert.SerializeObject(model);
	  var response = await _client.PutAsync($"{UrlLocator.ApiUrl}/document/edit", new StringContent(stringifiedObject, Encoding.Default, "application/json"));
	  return response.IsSuccessStatusCode;
	}

	public async Task<bool> DeleteDocument(int id)
	{
	  var response = await _client.DeleteAsync($"{UrlLocator.ApiUrl}/document/delete/{id}");
	  return response.IsSuccessStatusCode;
	}

	public async Task<bool> SetShowOnMain(int categoryId, int productLineId)
	{
	  var response = await _client.GetAsync($"{UrlLocator.ApiUrl}/category/{categoryId}/productline/{productLineId}/showonmain");
	  return response.IsSuccessStatusCode;
	}
  }
}
