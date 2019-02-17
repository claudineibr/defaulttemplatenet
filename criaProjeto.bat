SET PROJETO_PADRAO=ProjetoPadrao

cd ProjetoPadrao

ren %PROJETO_PADRAO%.ApplicationService %1.ApplicationService
ren %PROJETO_PADRAO%.Domain %1.Domain
ren %PROJETO_PADRAO%.MVC %1.MVC
ren %PROJETO_PADRAO%.Repository %1.Repository
ren %PROJETO_PADRAO%.WebApi %1.WebApi
ren %PROJETO_PADRAO%.CrossCutting.Commons %1.CrossCutting.Commons

fart %PROJETO_PADRAO%.sln "%PROJETO_PADRAO%." "%1."
fart .gitignore "%PROJETO_PADRAO%." "%1."
ren %PROJETO_PADRAO%.sln %1%.sln

cd %1.ApplicationService
..\fart %PROJETO_PADRAO%.ApplicationService.csproj "<RootNamespace>%PROJETO_PADRAO%." "<RootNamespace>%1."
..\fart %PROJETO_PADRAO%.ApplicationService.csproj "<AssemblyName>%PROJETO_PADRAO%." "<AssemblyName>%1."
..\fart MeuServico\MeuServicoApplicationService.cs "%PROJETO_PADRAO%." "%1."
..\fart Util\ExtensionMethods.cs "%PROJETO_PADRAO%." "%1."
..\fart Util\Json.cs "%PROJETO_PADRAO%." "%1."
ren %PROJETO_PADRAO%.ApplicationService.csproj %1%.ApplicationService.csproj
cd ..

cd %1.Domain
..\fart %PROJETO_PADRAO%.Domain.csproj "<RootNamespace>%PROJETO_PADRAO%." "<RootNamespace>%1."
..\fart %PROJETO_PADRAO%.Domain.csproj "<AssemblyName>%PROJETO_PADRAO%." "<AssemblyName>%1."
..\fart IApplicationService\IMeuServicoApplicationService.cs "%PROJETO_PADRAO%." "%1."
..\fart IRepository\IMeuServicoRepository.cs "%PROJETO_PADRAO%." "%1."
..\fart Model\MeuServico.cs "%PROJETO_PADRAO%." "%1."
ren %PROJETO_PADRAO%.Domain.csproj %1%.Domain.csproj
cd ..

cd %1.MVC
..\fart %PROJETO_PADRAO%.MVC.csproj "<RootNamespace>%PROJETO_PADRAO%." "<RootNamespace>%1."
..\fart %PROJETO_PADRAO%.MVC.csproj "<AssemblyName>%PROJETO_PADRAO%." "<AssemblyName>%1."
..\fart %PROJETO_PADRAO%.MVC.csproj "<Compile Include=\"ProjetoPadraoModule.cs\" />" "<Compile Include=\"%1Module.cs\" />"
..\fart %PROJETO_PADRAO%.MVC.csproj "%PROJETO_PADRAO%.ApplicationService" "%1.ApplicationService"
..\fart Controllers\HomeController.cs "%PROJETO_PADRAO%." "%1."
..\fart Global.asax.cs "%PROJETO_PADRAO%." "%1."
..\fart Global.asax "%PROJETO_PADRAO%." "%1."
..\fart App_Start\FilterConfig.cs "%PROJETO_PADRAO%." "%1."
..\fart App_Start\RouteConfig.cs "%PROJETO_PADRAO%." "%1."
..\fart App_Start\WebApiConfig.cs "%PROJETO_PADRAO%." "%1."
..\fart App_Start\BundleConfig.cs "%PROJETO_PADRAO%." "%1."
..\fart App_Start\UnityConfig.cs "%PROJETO_PADRAO%." "%1."
..\fart App_Start\UnityMvcActivator.cs "%PROJETO_PADRAO%." "%1."
..\fart App_Start\UnityConfig.cs "%PROJETO_PADRAO%Context" "%1Context"
ren %PROJETO_PADRAO%.MVC.csproj %1%.MVC.csproj
ren %PROJETO_PADRAO%.MVC.csproj.user %1%.MVC.csproj.user
cd ..

cd %1.Repository
..\fart %PROJETO_PADRAO%.Repository.csproj "<RootNamespace>%PROJETO_PADRAO%." "<RootNamespace>%1."
..\fart %PROJETO_PADRAO%.Repository.csproj "<AssemblyName>%PROJETO_PADRAO%." "<AssemblyName>%1."
..\fart %PROJETO_PADRAO%.Repository.csproj "<Compile Include=\"ProjetoPadraoContext.cs\" />" "<Compile Include=\"%1Context.cs\" />"
ren %PROJETO_PADRAO%.Repository.csproj %1%.Repository.csproj
..\fart Repository\MeuServicoRepository.cs "%PROJETO_PADRAO%." "%1."
..\fart EntityConfiguration\MeuServicoEntityConfiguration.cs "%PROJETO_PADRAO%." "%1."
..\fart ProjetoPadraoContext.cs "%PROJETO_PADRAO%." "%1."
..\fart ProjetoPadraoContext.cs "%PROJETO_PADRAO%Context " "%1Context "
..\fart ProjetoPadraoContext.cs "%PROJETO_PADRAO%Context()" "%1Context()"
..\fart ProjetoPadraoContext.cs "=%PROJETO_PADRAO%Context" "=%1Context"
ren ProjetoPadraoContext.cs %1Context.cs
cd ..

cd %1.WebApi
..\fart %PROJETO_PADRAO%.WebApi.csproj "<RootNamespace>%PROJETO_PADRAO%." "<RootNamespace>%1."
..\fart %PROJETO_PADRAO%.WebApi.csproj "<AssemblyName>%PROJETO_PADRAO%." "<AssemblyName>%1."
..\fart %PROJETO_PADRAO%.WebApi.csproj "%PROJETO_PADRAO%.ApplicationService" "%1.ApplicationService"
..\fart %PROJETO_PADRAO%.WebApi.csproj "%PROJETO_PADRAO%.Repository" "%1.Repository"
..\fart Web.config "%PROJETO_PADRAO%." "%1."
..\fart Global.asax.cs "%PROJETO_PADRAO%." "%1."
..\fart Global.asax "%PROJETO_PADRAO%." "%1."
..\fart NLog.config "%PROJETO_PADRAO%" "%1"
..\fart App_Start\BundleConfig.cs "%PROJETO_PADRAO%." "%1."
..\fart App_Start\FilterConfig.cs "%PROJETO_PADRAO%." "%1."
..\fart App_Start\UnityConfig.cs "%PROJETO_PADRAO%." "%1."
..\fart App_Start\UnityConfig.cs "%PROJETO_PADRAO%Context" "%1Context"
..\fart App_Start\RouteConfig.cs "%PROJETO_PADRAO%." "%1."
..\fart App_Start\WebApiConfig.cs "%PROJETO_PADRAO%." "%1."
..\fart Controllers\HomeController.cs "%PROJETO_PADRAO%." "%1."
..\fart Controllers\ValuesController.cs "%PROJETO_PADRAO%." "%1."
ren %PROJETO_PADRAO%.WebApi.csproj %1%.WebApi.csproj
ren %PROJETO_PADRAO%.WebApi.csproj.user %1%.WebApi.csproj.user
cd ..

cd %1.CrossCutting.Commons
..\fart %PROJETO_PADRAO%.CrossCutting.Commons.csproj "<RootNamespace>%PROJETO_PADRAO%." "<RootNamespace>%1."
..\fart %PROJETO_PADRAO%.CrossCutting.Commons.csproj "<AssemblyName>%PROJETO_PADRAO%." "<AssemblyName>%1."
..\fart Util\BaseHttpResponseMessage.cs "%PROJETO_PADRAO%." "%1."
ren %PROJETO_PADRAO%.CrossCutting.Commons.csproj %1%.CrossCutting.Commons.csproj
cd ..

del fart.exe
del bootstrap.bat
del criaProjeto.bat

REM Sai do diretorio ProjetoPadrao
cd ..

REM Cria um diretório com o nome do projeto
mkdir %1

REM Copia o conteúdo do diretório do projeto padrão já alterado para o diretório correto
xcopy /s ".\%PROJETO_PADRAO%" %1

REM Remove o PeD que não é mais necessário
rmdir /s /q ".\%PROJETO_PADRAO%"