#基于 microsoft/dotnet:1.0.0-core 或者 runtime 来构建我们的镜像适合直接运行发布的产品
#microsoft/dotnet:1.0-sdk-projectjson 适合在容器中执行项目的构建比如dotnet restore / publish 等dotnet指令 包括core和dotnet命令环境
FROM microsoft/dotnet:1.0-sdk-projectjson

#拷贝项目publish文件夹中的所有文件到 docker容器中的publish文件夹中
#RUN mkdir /publish

#COPY . /workspace

#RUN dotnet restore  ./workspace/src/JK.GISService/project.json

#RUN dotnet publish  ./workspace/src/JK.GISService/project.json  -c release -o /publish

COPY . /publish
#设置工作目录为 /publish 文件夹，即容器启动默认的文件夹

WORKDIR /publish


#设置Docker容器对外暴露60000端口

EXPOSE 5000


#使用dotnet JK.GISService.dll来运行应用程序

CMD ["dotnet", "JK.GISService.dll"]