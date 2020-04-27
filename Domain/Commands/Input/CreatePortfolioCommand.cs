using Domain.Commands.Abstracts;
using Domain.Commands.Interfaces;
using Domain.Commands.Output;

namespace Domain.Commands.Input
{
    public class CreatePortfolioCommand : Command<CreatePortfolioCommandResult>, IValidate
    {
        public string Name { get; set; }

        public bool Validate()
        {
            return Valid;
        }
    }
}
