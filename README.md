# QIQO.Business.Services.Solution
### This includes DAL, WCF, Business Engines, and more

This solution is the core to the overall QIQO solution. This is where the WCF services are hosted. This depends on the [QIQO.Database][13] for data, stored procedures, and such. 

This solution can be hosted via the [QIQO.ConsoleHost][9], which is good for development and testing, or the [QIQO.WindowsServiceHost][12], which is the best approach for a production environment.

- [QIQO.Business.Bootstrapper][1]  - The Unity bootstrapper assembly
- [QIQO.Business.Contracts][2] - The interface assembly containing most of the contracts
- [QIQO.Business.Engines][3] – The business engines and entity services
- [QIQO.Business.Services][4] – The WCF services
- [QIQO.CodeLogic.Test][5] – Unit tests
- [QIQO.Common.Contracts][6] – Common contracts (interfaces) that can be use outside of this solution if needed
- [QIQO.Common.Core][7] – Common code that can be shared with other solutions
- [QIQO.Common.Entities][8] – Business entities (POCOs)
- [QIQO.ConsoleHost][9] – Console host assembly
- [QIQO.Data.Entities][10] – Data entities (DTO POCOs)
- [QIQO.Data][11] – The data access layer; data contexts, repositories, mappers
- [QIQO.WindowsServiceHost][12] – Windows host assembly

[1]: https://github.com/rdrrichards/QIQO.Business.Services.Solution/tree/master/QIQO.Business.Bootstrapper
[2]: https://github.com/rdrrichards/QIQO.Business.Services.Solution/tree/master/QIQO.Business.Contracts
[3]: https://github.com/rdrrichards/QIQO.Business.Services.Solution/tree/master/QIQO.Business.Engines
[4]: https://github.com/rdrrichards/QIQO.Business.Services.Solution/tree/master/QIQO.Business.Services
[5]: https://github.com/rdrrichards/QIQO.Business.Services.Solution/tree/master/QIQO.CodeLogic.Test
[6]: https://github.com/rdrrichards/QIQO.Business.Services.Solution/tree/master/QIQO.Common.Contracts
[7]: https://github.com/rdrrichards/QIQO.Business.Services.Solution/tree/master/QIQO.Common.Core
[8]: https://github.com/rdrrichards/QIQO.Business.Services.Solution/tree/master/QIQO.Common.Entities
[9]: https://github.com/rdrrichards/QIQO.Business.Services.Solution/tree/master/QIQO.ConsoleHost
[10]: https://github.com/rdrrichards/QIQO.Business.Services.Solution/tree/master/QIQO.Data.Entities
[11]: https://github.com/rdrrichards/QIQO.Business.Services.Solution/tree/master/QIQO.Data
[12]: https://github.com/rdrrichards/QIQO.Business.Services.Solution/tree/master/QIQO.WindowsServiceHost
[13]: https://github.com/rdrrichards/QIQO.Database
