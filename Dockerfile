#���� microsoft/dotnet:1.0.0-core ���� runtime ���������ǵľ����ʺ�ֱ�����з����Ĳ�Ʒ
#microsoft/dotnet:1.0-sdk-projectjson �ʺ���������ִ����Ŀ�Ĺ�������dotnet restore / publish ��dotnetָ�� ����core��dotnet�����
FROM microsoft/dotnet:1.0-sdk-projectjson

#������Ŀpublish�ļ����е������ļ��� docker�����е�publish�ļ�����
#RUN mkdir /publish

#COPY . /workspace

#RUN dotnet restore  ./workspace/src/JK.GISService/project.json

#RUN dotnet publish  ./workspace/src/JK.GISService/project.json  -c release -o /publish

COPY . /publish
#���ù���Ŀ¼Ϊ /publish �ļ��У�����������Ĭ�ϵ��ļ���

WORKDIR /publish


#����Docker�������Ⱪ¶60000�˿�

EXPOSE 5000


#ʹ��dotnet JK.GISService.dll������Ӧ�ó���

CMD ["dotnet", "JK.GISService.dll"]