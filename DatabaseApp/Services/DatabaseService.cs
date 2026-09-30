using DatabaseApp.Models;
using SQLite;
namespace DatabaseApp.Services;

public class DatabaseService
{
    SQLiteAsyncConnection db;
    async Task Init()
    {
        if (db != null)
            return;
        string ruta =
        Path.Combine(FileSystem.AppDataDirectory,
        "estudiantes.db3");
        db = new SQLiteAsyncConnection(ruta);
        await db.CreateTableAsync <Estudiante>();
    }
    public async Task<List<Estudiante>> ObtenerTodos()
    {
        await Init();
        return await db.Table <Estudiante>().ToListAsync();
    }

    public async Task Guardar(Estudiante estudiante)
    {
        await Init();
        if (estudiante.Id != 0)
            await db.UpdateAsync(estudiante);
        else
            await db.InsertAsync(estudiante);
    }
    public async Task Eliminar(Estudiante estudiante)
    {
        await Init();
        await db.DeleteAsync(estudiante);
    }
}