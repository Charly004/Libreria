using System.Net.Http.Json;
using System.Text.Json;

namespace blazorlibreria;  

public class LibreriaService: ILibreriaService
{
    private readonly HttpClient client;
    private readonly JsonSerializerOptions options;


    public LibreriaService(HttpClient cliente)
    {
        client = cliente;
        options = new JsonSerializerOptions{PropertyNameCaseInsensitive=true};
    }

    public async Task<List<Libreria>?> Get()
    {
        var response = await client.GetAsync("Libreria");
        var Content = await response.Content.ReadAsStringAsync();

        if(!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(Content);
        }
        return JsonSerializer.Deserialize<List<Libreria>>(Content, options);
    }

    public async Task Add(Libreria libreria)
    {
        var response = await client.PostAsync("Libreria/Post", JsonContent.Create(libreria));
        var Content = await response.Content.ReadAsStringAsync();
        if(!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(Content);
        }
    }

    public async Task Delete(int CodigoLibro)
    {
        var response = await client.DeleteAsync($"Libreria/{CodigoLibro}");
        var Content = await response.Content.ReadAsStringAsync();
        if(!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(Content);
        }
    }
    
}

public interface ILibreriaService
{
       Task<List<Libreria>?> Get();
       Task Add(Libreria libreria);
       Task Delete(int CodigoLibro);
}