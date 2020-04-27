using Domain.Commands.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Commands.Output
{
    public class CreatePortfolioCommandResult : CommandResult
    {
        public object Id { get; set; }
    }
}
