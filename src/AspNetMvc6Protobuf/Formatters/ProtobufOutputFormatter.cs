﻿using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Net.Http.Headers;
using ProtoBuf.Meta;

namespace AspNetMvc6Protobuf.Formatters
{
    public class ProtobufOutputFormatter :  OutputFormatter
    {
        private static Lazy<RuntimeTypeModel> model = new Lazy<RuntimeTypeModel>(CreateTypeModel);

        public string ContentType { get; private set; }

        public static RuntimeTypeModel Model
        {
            get { return model.Value; }
        }

        public ProtobufOutputFormatter()
        {
            ContentType = "application/x-protobuf";
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/x-protobuf"));
            SupportedEncodings.Add(Encoding.GetEncoding("utf-8"));
        }

        public override bool CanWriteResult(OutputFormatterContext context, MediaTypeHeaderValue contentType)
        {
            return true;
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterContext context)
        {
            var response = context.HttpContext.Response;
            var selectedEncoding = context.SelectedEncoding;

            Model.Serialize(response.Body, context.Object);
            return;

            // await response.Body.WriteAsync(valueAsString, context.SelectedEncoding);
        }

        private static RuntimeTypeModel CreateTypeModel()
        {
            var typeModel = TypeModel.Create();
            typeModel.UseImplicitZeroDefaults = false;
            return typeModel;
        }

    }
}
