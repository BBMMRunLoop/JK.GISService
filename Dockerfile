#���� microsoft/dotnet:1.0.0-core ���������ǵľ���
FROM microsoft/dotnet:1.0-sdk-projectjson

#������Ŀpublish�ļ����е������ļ��� docker�����е�publish�ļ�����
RUN mkdir /publish

COPY . /workspace

RUN cd ./workspace/src/JK.GISService

RUN dotnet publish -c release -o /publish
#���ù���Ŀ¼Ϊ /publish �ļ��У�����������Ĭ�ϵ��ļ���

WORKDIR /publish


#����Docker�������Ⱪ¶60000�˿�

EXPOSE 5000


#ʹ��dotnet JK.GISService.dll������Ӧ�ó���

CMD ["dotnet", "JK.GISService.dll"]