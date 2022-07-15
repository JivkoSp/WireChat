using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wire.Data.Repository.UnitOfWork;

namespace Wire.Middlewares
{
    public class DeleteMessagesMiddleware
    {
        private RequestDelegate Next;

        public DeleteMessagesMiddleware(RequestDelegate requestDelegate)
        {
            Next = requestDelegate;
        }

        public async Task Invoke(HttpContext httpContext, IUnitOfWork unitOfWork)
        {
            var messages = unitOfWork.MessageRepo.GetMessages();

            var oldMessages = messages.Where(m => m.MessageLifeTime.CompareTo(DateTime.Now) <= 0);

            if(oldMessages != null)
            {
                unitOfWork.MessageRepo.RemoveRange(oldMessages);
                await unitOfWork.SaveChangesAsync();
            }

            await Next(httpContext);
        }
    }
}
