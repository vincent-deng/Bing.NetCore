﻿using System;
using System.Threading.Tasks;
using Bing.Samples.Service.Abstractions;
using Bing.Samples.Service.Requests;
using Bing.Webs.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Bing.Samples.Controllers
{
    /// <summary>
    /// 测试 控制器
    /// </summary>
    public class TestController : ApiControllerBase
    {
        /// <summary>
        /// 初始化一个<see cref="TestController"/>类型的实例
        /// </summary>
        /// <param name="testService">测试服务</param>
        public TestController(ITestService testService)
        {
            TestService = testService;
        }

        /// <summary>
        /// 测试服务
        /// </summary>
        public ITestService TestService { get; set; }

        /// <summary>
        /// 获取字符串
        /// </summary>
        /// <param name="id">标识</param>
        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetAsync(Guid id)
        {
            var result = await TestService.GetAsync(id);
            return Success(result);
        }

        /// <summary>
        /// 获取元祖字符串
        /// </summary>
        /// <param name="id">标识</param>
        [HttpGet("getTuple")]
        public async Task<IActionResult> GetTupleAsync(Guid id)
        {
            var result = await TestService.GetTupleAsync(id);
            return Success(result);
        }

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="content">内容</param>
        [HttpPost("writeLog")]
        public async Task<IActionResult> WriteLogAsync([FromBody] string content)
        {
            await TestService.WriteLogAsync(content);
            return Success();
        }

        /// <summary>
        /// 测试枚举
        /// </summary>
        /// <param name="e">枚举</param>
        [HttpGet("testEnum")]
        public Task<IActionResult> TestEnumAsync([FromQuery]TestEnum e)
        {
            return Task.FromResult(Success());
        }

        /// <summary>
        /// 测试验证
        /// </summary>
        /// <param name="request">请求</param>
        [HttpPost("testValidate")]
        public Task<IActionResult> TestValidateAsync([FromBody] ValidSampleRequest request)
        {
            return Task.FromResult(Success());
        }

        /// <summary>
        /// 测试AOP验证
        /// </summary>
        /// <param name="request">请求</param>
        [HttpPost("testAopValidate")]
        public async Task<IActionResult> TestAopValidateAsync([FromBody] ValidSampleRequest request)
        {
            await TestService.TestAopValidateAsync(request);
            return Success();
        }
    }

    public enum TestEnum
    {
        One,
        Two,
        Three
    }
}
