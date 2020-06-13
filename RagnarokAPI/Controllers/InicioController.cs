using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RagnarokAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InicioController : ControllerBase
    {
        [HttpGet]
        public ContentResult Get()
        {
            var inicio =
                "<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>Ragnarök API</title>\r\n    <style>\r\n        body {\r\n  background-color: #2F3242;\r\n}\r\nsvg {\r\n  position: absolute;\r\n  top: 50%;\r\n  left: 50%;\r\n  margin-top: -250px;\r\n  margin-left: -400px;\r\n}\r\n.message-box {\r\n  height: 200px;\r\n  width: 380px;\r\n  position: absolute;\r\n  top: 50%;\r\n  left: 50%;\r\n  margin-top: -100px;\r\n  margin-left: auto;\r\n  color: #FFF;\r\n  font-family: Roboto;\r\n  font-weight: 300;\r\n}\r\n.message-box h1 {\r\n  font-size: 40px;\r\n  line-height: 46px;\r\n  margin-bottom: 40px;\r\n}\r\n.buttons-con .action-link-wrap {\r\n  margin-top: 40px;\r\n}\r\n.buttons-con .action-link-wrap a {\r\n  background: #68c950;\r\n  padding: 8px 25px;\r\n  border-radius: 4px;\r\n  color: #FFF;\r\n  font-weight: bold;\r\n  font-size: 14px;\r\n  transition: all 0.3s linear;\r\n  cursor: pointer;\r\n  text-decoration: none;\r\n  margin-right: 10px\r\n}\r\n.buttons-con .action-link-wrap a:hover {\r\n  background: #5A5C6C;\r\n  color: #fff;\r\n}\r\n\r\n#Polygon-1 , #Polygon-2 , #Polygon-3 , #Polygon-4 , #Polygon-4, #Polygon-5 {\r\n  animation: float 1s infinite ease-in-out alternate;\r\n}\r\n#Polygon-2 {\r\n  animation-delay: .2s; \r\n}\r\n#Polygon-3 {\r\n  animation-delay: .4s; \r\n}\r\n#Polygon-4 {\r\n  animation-delay: .6s; \r\n}\r\n#Polygon-5 {\r\n  animation-delay: .8s; \r\n}\r\n\r\n@keyframes float {\r\n\t100% {\r\n    transform: translateY(20px);\r\n  }\r\n}\r\n@media (max-width: 450px) {\r\n  svg {\r\n    position: absolute;\r\n    top: 50%;\r\n    left: 50%;\r\n    margin-top: -250px;\r\n    margin-left: -190px;\r\n  }\r\n  .message-box {\r\n    top: 50%;\r\n    left: 50%;\r\n    margin-top: -100px;\r\n    margin-left: -190px;\r\n    text-align: center;\r\n  }\r\n}\r\n    </style>\r\n</head>\r\n<body>\r\n    \r\n<svg width=\"380px\" height=\"500px\" viewBox=\"0 0 837 1045\" version=\"1.1\" xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" xmlns:sketch=\"http://www.bohemiancoding.com/sketch/ns\">\r\n    <g id=\"Page-1\" stroke=\"none\" stroke-width=\"1\" fill=\"none\" fill-rule=\"evenodd\" sketch:type=\"MSPage\">\r\n        <path d=\"M353,9 L626.664028,170 L626.664028,487 L353,642 L79.3359724,487 L79.3359724,170 L353,9 Z\" id=\"Polygon-1\" stroke=\"#007FB2\" stroke-width=\"6\" sketch:type=\"MSShapeGroup\"></path>\r\n        <path d=\"M78.5,529 L147,569.186414 L147,648.311216 L78.5,687 L10,648.311216 L10,569.186414 L78.5,529 Z\" id=\"Polygon-2\" stroke=\"#EF4A5B\" stroke-width=\"6\" sketch:type=\"MSShapeGroup\"></path>\r\n        <path d=\"M773,186 L827,217.538705 L827,279.636651 L773,310 L719,279.636651 L719,217.538705 L773,186 Z\" id=\"Polygon-3\" stroke=\"#795D9C\" stroke-width=\"6\" sketch:type=\"MSShapeGroup\"></path>\r\n        <path d=\"M639,529 L773,607.846761 L773,763.091627 L639,839 L505,763.091627 L505,607.846761 L639,529 Z\" id=\"Polygon-4\" stroke=\"#F2773F\" stroke-width=\"6\" sketch:type=\"MSShapeGroup\"></path>\r\n        <path d=\"M281,801 L383,861.025276 L383,979.21169 L281,1037 L179,979.21169 L179,861.025276 L281,801 Z\" id=\"Polygon-5\" stroke=\"#36B455\" stroke-width=\"6\" sketch:type=\"MSShapeGroup\"></path>\r\n    </g>\r\n</svg>\r\n<div class=\"message-box\">\r\n  <h1>Hello, Ragnarok API!</h1>\r\n  <p>Version : 1.0.4</p>\r\n  <div class=\"buttons-con\">\r\n    <div class=\"action-link-wrap\">\r\n      <a href=\"https://github.com/xjhofernandes/RagnarokAPI\" class=\"link-button\">Acesse o repositório!</a>\r\n    </div>\r\n  </div>\r\n</div>\r\n</body>\r\n</html>\r\n";
            return base.Content(inicio, "text/html");
        }
    }
}
