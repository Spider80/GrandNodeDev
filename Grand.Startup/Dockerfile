FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
RUN apt-get update -qq && apt-get -y install libgdiplus libc6-dev

EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Grand.Host/Grand.Host.csproj", "Grand.Host/"]
COPY ["Grand.Web/Grand.Web.csproj", "Grand.Web/"]
COPY ["Grand.Admin/Grand.Admin.csproj", "Grand.Admin/"]
COPY ["Grand.Framework/Grand.Framework.csproj", "Grand.Framework/"]
COPY ["Grand.Domain/Grand.Domain.csproj", "Grand.Domain/"]
COPY ["Grand.Core/Grand.Core.csproj", "Grand.Core/"]
COPY ["Grand.Services/Grand.Services.csproj", "Grand.Services/"]
COPY ["Grand.Api/Grand.Api.csproj", "Grand.Api/"]
RUN dotnet restore "Grand.Host/Grand.Host.csproj"
COPY . .
WORKDIR "/src/Grand.Host"
RUN dotnet build "Grand.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Grand.Host.csproj" -c Release -o /app/publish


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

RUN chmod 755 /app/Rotativa/Linux/wkhtmltopdf

ENTRYPOINT ["dotnet", "Grand.Host.dll"]