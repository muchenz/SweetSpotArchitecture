
# Build stage 

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

# restore 

COPY ["src/OneReview/OneReview.csproj", "OneReview/" ]
RUN dotnet restore "OneReview/OneReview.csproj"

# build 

COPY ["src/OneReview", "OneReview/" ]
WORKDIR /src/OneReview
RUN dotnet build  "OneReview.csproj" -c Release -o  /app/build

# publish

FROM build as publish
RUN dotnet publish  "OneReview.csproj" -c Release -o  /app/publish

# run

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS build
ENV ASPNETCORE_HTTP_PORTS=5001
EXPOSE 5001
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OneReview.dll"]


# docker build -t one-review-youtube .
# docker image ls | grep one-review-youtub
# docker image ls | Select-String one-review-youtube

# docker run -p 5001:5001 --name one-review-youtube one-review-youtube 

# docker image ls

# docker compode up --build