using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlerTests
{
    [TestClass]
    public class CreateTodoHandlerTests
    {
        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", DateTime.Now, "");
        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Titulo", DateTime.Now, "Marcos");
        private readonly TodoHandler _handler = new TodoHandler(new FakeTodoRepositories());

        [TestMethod]
        public void Dado_um_comnado_invalido_deve_interromper_a_execucao ()
        {
            var result = (GenericCommandResult) _handler.Handle(_invalidCommand);
            Assert.AreEqual(result.Sucess, false);
        }

        [TestMethod]
        public void Dado_um_comnado_valido_deve_criar_a_tarefa()
        {
            var result = (GenericCommandResult)_handler.Handle(_validCommand);
            Assert.AreEqual(result.Sucess, true);
        }
    }
}
