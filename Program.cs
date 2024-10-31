var builder = WebApplication.CreateBuilder();
var app = builder.Build();

List<Characters> characters = new List<Characters>()
{
    new Characters("лоусе","прзыватель",13,"форт радость"),
    new Characters("зверь","hf",17,"форт радость"),
    new Characters("фейн","dfb",19,"форт радость")
};
app.MapGet("/", () => characters);
app.MapPost("/", (Characters ch) => characters.Add(ch));
app.MapPut("/{id}", (string id, CharactersDTO dto) =>
{
    Characters buffer = characters.Find(x => x.Name == id);
    buffer.Role = dto.Role;
    buffer.Lvl = dto.Lvl;
    buffer.Main_quest = dto.Main_quest;
});
app.MapDelete("/{name}", (string name) =>
{
    Characters buffer = characters.Find(x => x.Name == name);
    characters.Remove(buffer);
});

app.Run();

record class CharactersDTO(string Role, int Lvl, string Main_quest);

class Characters
{
    string name;
    string role;
    int lvl;
    string main_quest;

    public Characters(string name, string role, int lvl, string main_quest)
    {
        Name = name;
        Role = role;
        Lvl = lvl;
        Main_quest = main_quest;
    }

    public string Name { get => name; set => name = value; }
    public string Role { get => role; set => role = value; }
    public int Lvl { get => lvl; set => lvl = value; }
    public string Main_quest { get => main_quest; set => main_quest = value; }
}