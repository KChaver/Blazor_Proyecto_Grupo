﻿using Datos.Interfaces;
using Datos.Repositorio;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using System.Security.Claims;
using BlazorGrupo.Data;

namespace BlazorGrupo.Controllers;
    public class LoginController : Controller
    {
            private readonly MySQLConfiguration _configuration;
            private IUsuarioRepositorio _usuarioRepositorio;

            public LoginController(MySQLConfiguration configuration)
            {
                _configuration = configuration;
                _usuarioRepositorio = new UsuarioRepositorio(configuration.CadenaConexion);
            }

            [HttpPost("/account/login")]

            public async Task<IActionResult> Login(Login login)
            {
                string rol = string.Empty;
                try
                {
                    bool usuariovalido = await _usuarioRepositorio.ValidaUsuario(login);
                    if (usuariovalido)
                {
                    Usuario usu = await _usuarioRepositorio.GetPorCodigo(login.Codigo);
                    if (usu.EstaActivo)
                    {
                        rol = usu.Rol;

                        var claims = new[]
                        {
                            new Claim(ClaimTypes.Name, usu.Codigo),
                            new Claim(ClaimTypes.Role, rol)
                        };

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal,
                            new AuthenticationProperties
                            {
                                IsPersistent = true,
                                ExpiresUtc = DateTime.UtcNow.AddMinutes(20)

                            });
                    }
                    else
                    {
                        return LocalRedirect("/login/Usuario Inactivo");
                    }
                }
                else
                {
                    return LocalRedirect("/login/ Datos de usuario Invalido");
                }
            }
            catch (Exception ex)
            {
                return LocalRedirect("/login/ Datos de usuario Invalido");
            }
            return LocalRedirect("/"); 
         }

        [HttpGet("/account/logout")]

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return LocalRedirect("/");
        }
    }
    
