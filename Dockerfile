#基于 microsoft/dotnet:1.0.0-core 来构建我们的镜像
FROM microsoft/dotnet:1.0-sdk-projectjson

#拷贝项目publish文件夹中的所有文件到 docker容器中的publish文件夹中
RUN mkdir /publish

COPY . /workspace

RUN cd ./workspace/src/JK.GISService

RUN dotnet publish -c release -o /publish
#设置工作目录为 /publish 文件夹，即容器启动默认的文件夹

WORKDIR /publish


#设置Docker容器对外暴露60000端口

EXPOSE 5000


#使用dotnet JK.GISService.dll来运行应用程序

CMD ["dotnet", "JK.GISService.dll"]