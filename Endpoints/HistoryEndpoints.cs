using EventHistory.Database;
using Microsoft.EntityFrameworkCore;

namespace EventHistory.Endpoints
{
    public static class HistoryEndpoints
    {
        public static void MapHistoryEndpoints(this WebApplication app)
        {
            app.MapGet("/history", async (EventHistoryContext context) =>
            {
                var history = await context.TestTable.ToListAsync();
                return Results.Ok(history);
            });

            //app.MapGet("/history/{id}", async (EventHistoryContext context, int id) =>
            //{
            //    var history = await context.History.FindAsync(id);
            //    return history is null ? Results.NotFound() : Results.Ok(history);
            //});

            //app.MapPost("/history", async (EventHistoryContext context, History history) =>
            //{
            //    context.History.Add(history);
            //    await context.SaveChangesAsync();
            //    return Results.Created($"/history/{history.Id}", history);
            //});

            //app.MapPut("/history/{id}", async (EventHistoryContext context, int id, History history) =>
            //{
            //    if (id != history.Id)
            //    {
            //        return Results.BadRequest();
            //    }

            //    context.Entry(history).State = EntityState.Modified;
            //    await context.SaveChangesAsync();
            //    return Results.NoContent();
            //});

            //app.MapDelete("/history/{id}", async (EventHistoryContext context, int id) =>
            //{
            //    var history = await context.History.FindAsync(id);
            //    if (history is null)
            //    {
            //        return Results.NotFound();
            //    }

            //    context.History.Remove(history);
            //    await context.SaveChangesAsync();
            //    return Results.NoContent();
            //});
        }   
    }
}
