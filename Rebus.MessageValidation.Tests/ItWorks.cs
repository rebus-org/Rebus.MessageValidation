using NUnit.Framework;
using Rebus.Activation;
using Rebus.Config;
using Rebus.Tests.Contracts;
using Rebus.Transport.InMem;

namespace Rebus.MessageValidation.Tests
{
    [TestFixture]
    public class ItWorks : FixtureBase
    {
        protected override void SetUp()
        {
            var activator = new BuiltinHandlerActivator();

            Using(activator);

            Configure.With(activator)
                .Transport(t => t.UseInMemoryTransport(new InMemNetwork(), "validation-check"))
                .Options(o => o.EnableMessageValidation())
                .Start();
        }
    }
}