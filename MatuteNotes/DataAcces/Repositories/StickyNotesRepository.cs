using MatuteNotes.DataAcces.AdoNet;
using MatuteNotes.Domain.Models;
using MatuteNotes.Domain.Queries.StickyQueries;
using MatuteNotes.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatuteNotes.DataAcces.Repositories
{
   
    public class StickyNotesRepository : IStickyNoteRepository
    {
        public readonly AdoContext _adoContext;

        public StickyNotesRepository(AdoContext adoContext)
        {
            _adoContext = adoContext;
        }

        public async Task<IEnumerable<StickyQuery>> GetListado(StickyQueryParams @params)
        {
            string sqlString = "UspStickyNoteSearch";
            var response = await _adoContext.ExecuteReader<StickyQuery>(
                sqlString,
                System.Data.CommandType.StoredProcedure,
                new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@Completed", @params.Completed),
                    new System.Data.SqlClient.SqlParameter("@IdUser", @params.IdUser),
                    new System.Data.SqlClient.SqlParameter("@FilterDate", @params.FilterDate),
                    new System.Data.SqlClient.SqlParameter("@StartDate", @params.StarDate),
                    new System.Data.SqlClient.SqlParameter("@EndDate", @params.EndDate)


                });
            return response;
        }

        public async Task<int> SetData(StickyNote note, string acccion)
        {
            string sqlString = "UspStickyNoteMerge";
            var response = await _adoContext.ExecuteNonQuery(
                sqlString,
                System.Data.CommandType.StoredProcedure,
                new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@Id",note.Id ),
                    new System.Data.SqlClient.SqlParameter("@Cliente", note.Cliente),
                    new System.Data.SqlClient.SqlParameter("@Content", note.Content),
                    new System.Data.SqlClient.SqlParameter("@Completed", note.Completed),
                    new System.Data.SqlClient.SqlParameter("@IdUser", note.IdUser),
                    new System.Data.SqlClient.SqlParameter("@Priority", note.Priority),
                    new System.Data.SqlClient.SqlParameter("@Deleted", note.Deleted),
                    new System.Data.SqlClient.SqlParameter("@Height", note.Height),
                    new System.Data.SqlClient.SqlParameter("@action", acccion)

                });
            return response;
        }
    }
}
