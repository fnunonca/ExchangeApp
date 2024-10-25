# Crear la solución 'Exchange'
dotnet new sln -n Exchange

# Crear proyectos de la capa de Infraestructura
dotnet new classlib -o Infraestructure.Data -f net8.0
dotnet new classlib -o Infraestructure.Interface -f net8.0
dotnet new classlib -o Infraestructure.Repository -f net8.0
dotnet sln Exchange.sln add Infraestructure.Data\Infraestructure.Data.csproj --solution-folder '01 Infraestructure'
dotnet sln Exchange.sln add Infraestructure.Interface\Infraestructure.Interface.csproj --solution-folder '01 Infraestructure'
dotnet sln Exchange.sln add Infraestructure.Repository\Infraestructure.Repository.csproj --solution-folder '01 Infraestructure'

# Crear proyectos de la capa de Dominio
dotnet new classlib -o Domain.Core -f net8.0
dotnet new classlib -o Domain.Entity -f net8.0
dotnet new classlib -o Domain.Interface -f net8.0
dotnet sln Exchange.sln add Domain.Core\Domain.Core.csproj --solution-folder '02 Domain'
dotnet sln Exchange.sln add Domain.Entity\Domain.Entity.csproj --solution-folder '02 Domain'
dotnet sln Exchange.sln add Domain.Interface\Domain.Interface.csproj --solution-folder '02 Domain'

# Crear proyectos de la capa de Aplicación
dotnet new classlib -o Application.DTO -f net8.0
dotnet new classlib -o Application.Interface -f net8.0
dotnet new classlib -o Application.Main -f net8.0
dotnet sln Exchange.sln add Application.DTO\Application.DTO.csproj --solution-folder '03 Application'
dotnet sln Exchange.sln add Application.Interface\Application.Interface.csproj --solution-folder '03 Application'
dotnet sln Exchange.sln add Application.Main\Application.Main.csproj --solution-folder '03 Application'

# Crear el proyecto Web API
dotnet new webapi -o Service.Api -f net8.0
dotnet sln Exchange.sln add Service.Api\Service.Api.csproj --solution-folder '04 Service'

# Crear proyectos de la capa Transversal
dotnet new classlib -o Transversal.Common -f net8.0
dotnet new classlib -o Transversal.Logging -f net8.0
dotnet sln Exchange.sln add Transversal.Common\Transversal.Common.csproj --solution-folder '05 Transversal'
dotnet sln Exchange.sln add Transversal.Logging\Transversal.Logging.csproj --solution-folder '05 Transversal'

# Aquí puedes agregar la sección de creación y adición de los proyectos de prueba si lo deseas

# Agregar referencias entre los proyectos
dotnet add Infraestructure.Data\Infraestructure.Data.csproj reference Transversal.Common\Transversal.Common.csproj
dotnet add Infraestructure.Interface\Infraestructure.Interface.csproj reference Domain.Entity\Domain.Entity.csproj
dotnet add Infraestructure.Repository\Infraestructure.Repository.csproj reference Infraestructure.Data\Infraestructure.Data.csproj
dotnet add Infraestructure.Repository\Infraestructure.Repository.csproj reference Infraestructure.Interface\Infraestructure.Interface.csproj

dotnet add Domain.Core\Domain.Core.csproj reference Domain.Entity\Domain.Entity.csproj
dotnet add Domain.Core\Domain.Core.csproj reference Domain.Interface\Domain.Interface.csproj
dotnet add Domain.Core\Domain.Core.csproj reference Infraestructure.Interface\Infraestructure.Interface.csproj
dotnet add Domain.Interface\Domain.Interface.csproj reference Domain.Entity\Domain.Entity.csproj

dotnet add Application.Interface\Application.Interface.csproj reference Application.DTO\Application.DTO.csproj
dotnet add Application.Interface\Application.Interface.csproj reference Transversal.Common\Transversal.Common.csproj
dotnet add Application.Main\Application.Main.csproj reference Application.DTO\Application.DTO.csproj
dotnet add Application.Main\Application.Main.csproj reference Application.Interface\Application.Interface.csproj
dotnet add Application.Main\Application.Main.csproj reference Domain.Entity\Domain.Entity.csproj
dotnet add Application.Main\Application.Main.csproj reference Domain.Interface\Domain.Interface.csproj

dotnet add Service.Api\Service.Api.csproj reference Application.DTO\Application.DTO.csproj
dotnet add Service.Api\Service.Api.csproj reference Application.Interface\Application.Interface.csproj
dotnet add Service.Api\Service.Api.csproj reference Application.Main\Application.Main.csproj
dotnet add Service.Api\Service.Api.csproj reference Transversal.Logging\Transversal.Logging.csproj

dotnet add Transversal.Logging\Transversal.Logging.csproj reference Transversal.Common\Transversal.Common.csproj


# Agregar los paquetes NuGet necesarios a los proyectos
dotnet add Infraestructure.Data package Microsoft.Extensions.Configuration
dotnet add Infraestructure.Data package System.Data.SqlClient
dotnet add Infraestructure.Repository package Dapper
dotnet add Infraestructure.Repository package Microsoft.Extensions.Options

dotnet add Service.Api package Newtonsoft.Json
dotnet add Service.Api package NLog
dotnet add Service.Api package NLog.Web.AspNetCore
dotnet add Service.Api package Microsoft.AspNetCore.Cors
dotnet add Service.Api package Swashbuckle.AspNetCore
