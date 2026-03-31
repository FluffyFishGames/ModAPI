[![English](https://img.shields.io/badge/English-🇺🇸-blue)](../README.md)
[![한국어](https://img.shields.io/badge/한국어-🇰🇷-red)](README.ko.md)
[![Deutsch](https://img.shields.io/badge/Deutsch-🇩🇪-black)](README.de.md)
[![Español](https://img.shields.io/badge/Español-🇪🇸-yellow)](README.es.md)
[![Français](https://img.shields.io/badge/Français-🇫🇷-blue)](README.fr.md)
[![Polski](https://img.shields.io/badge/Polski-🇵🇱-red)](README.pl.md)
[![Русский](https://img.shields.io/badge/Русский-🇷🇺-blue)](README.ru.md)
[![Italiano](https://img.shields.io/badge/Italiano-🇮🇹-green)](README.it.md)
[![日本語](https://img.shields.io/badge/日本語-🇯🇵-red)](README.jp.md)
[![Português](https://img.shields.io/badge/Português-🇵🇹-green)](README.pt.md)
[![Tiếng Việt](https://img.shields.io/badge/Tiếng%20Việt-🇻🇳-green)](README.vi.md)
[![简体中文](https://img.shields.io/badge/简体中文-🇨🇳-red)](README.zh-CN.md)
[![繁體中文](https://img.shields.io/badge/繁體中文-🇹🇼-blue)](README.zh-TW.md)

# ModAPI(v1) v2.0.9586 - 20260331

**Ferramenta de Gestão de Mods do The Forest — Edição Atualizada**

> Original: FluffyFish / Philipp Mohrenstecher (Engelskirchen, Alemanha)
> Atualização: zzangae (República da Coreia)

---

## Visão Geral

ModAPI é uma aplicação desktop para gerir mods do The Forest. Esta edição atualizada inclui migração para .NET Framework 4.8, interface Windows 11 Fluent Design, sistema de 3 temas, suporte multilingue melhorado, implementação completa do separador Downloads e suporte para desenvolvimento de mods em C# 7.3.

---

## O que mudou na v2.0.9586

| # | Categoria | Problema | Solução |
|---|---|---|---|
| 1 | **Crítico** | Ecrã negro no menu principal após aplicar mods | Resolvido — pipeline de remapeamento de assemblagens patcha corretamente cabeçalhos PE e tabelas de referências |
| 2 | **Polyfill** | `Portable.System.ValueTuple.dll` incluído mas não funcional | Removido completamente — `mscorlib` do Mono 2.0 gera IL com referência direta a `ValueTuple`; nenhum polyfill pode substituir |
| 3 | **Polyfill** | Nome de ficheiro incorreto: `System.Threading.Tasks.dll` | Corrigido para `System.Threading.dll` — nome real do NuGet `TaskParallelLibrary 1.0.2856` |
| 4 | **Polyfill** | Bug de caminho de cópia em `Game.cs`: ficheiros copiados para `Managed\polyfills\` | Corrigido com `Path.GetFileName()` para cópia plana em `Managed\` |
| 5 | **Build** | Target PostBuild sem auto-cópia de polyfills | `BaseModLib.csproj` PostBuild agora copia automaticamente `AsyncBridge.dll` e `System.Threading.dll` |
| 6 | **C# 7.3** | Suporte de tuples tentado e falhado | Definitivamente removido — limite arquitetural no Mono 2.0 |
| 7 | **C# 7.3** | Verificação em jogo de funcionalidades C# 7.3 | Confirmado: pattern matching, interpolação de cadeias, variável `out` inline |

### Matriz Final de Funcionalidades C# 7.3

| Funcionalidade | Estado | Notas |
|---|---|---|
| Pattern matching (`is`, `switch`) | ✅ Confirmado | Testado em jogo via `TEST_MOD.log` |
| Interpolação de cadeias (`$""`) | ✅ Confirmado | Testado em jogo via `TEST_MOD.log` |
| Variável `out` inline | ✅ Confirmado | Testado em jogo via `TEST_MOD.log` |
| Membros com corpo de expressão (`=>`) | ✅ | Gerido pelo compilador |
| Funções locais | ✅ | Gerido pelo compilador |
| `nameof` | ✅ | Gerido pelo compilador |
| Operador null-condicional (`?.`, `??`) | ✅ | Gerido pelo compilador |
| `async`/`await` | ✅ | Via polyfills AsyncBridge + System.Threading |
| Tuples (`ValueTuple`) | ❌ Limite duro | ABI mscorlib Mono 2.0 — sem solução |

### Configuração Final de Polyfills

| DLL | Pacote NuGet | Destino | Propósito |
|---|---|---|---|
| `AsyncBridge.dll` | AsyncBridge 0.3.1 | `libs/polyfills/` → `Managed/` | `async`/`await` para .NET 3.5 |
| `System.Threading.dll` | TaskParallelLibrary 1.0.2856 | `libs/polyfills/` → `Managed/` | Dependência AsyncBridge |
| ~~`Portable.System.ValueTuple.dll`~~ | ~~Removido~~ | ~~Removido~~ | ~~Não funcional no Mono 2.0~~ |

---

## Arquitetura de Runtime

| Componente | Alvo | Runtime | Motivo |
|---|---|---|---|
| `ModAPI.exe` | .NET Framework 4.8 | Windows .NET 4.8 | Aplicação desktop |
| `BaseModLib.dll` | .NET Framework 3.5 | Jogo Mono 2.0 | **Permanentemente fixo** |
| DLLs de Mod | .NET Framework 4.8 | Jogo Mono 2.0 (remendado) | Cabeçalho PE remendado ao aplicar |

```
Build v3.5  →  Cabeçalho PE: CLR Runtime v2.0.50727  ←  Mono 2.0 aceita  ✅
Build v4.8  →  Cabeçalho PE: CLR Runtime v4.0.30319  ←  Mono 2.0 recusa  ❌
```

---

## Histórico de Versões

| Versão | Data | Resumo |
|---|---|---|
| v2.0.9586 | 2026-03-31 | Ecrã negro resolvido, pipeline polyfill finalizada, ValueTuple removido, bugs corrigidos, C# 7.3 verificado |
| v2.0.9561 | 2026-03-06 | Suporte mods C# 7.3, patch cabeçalho PE, pipeline polyfill |
| v2.0.9552 | 2026-02-25 | Separador downloads, ícones, 13 idiomas |
| v2.0.9500 | — | Sistema de temas, Fluent Design UI |
| v2.0.9400 | — | Limpeza de código |
| v2.0.9300 | — | Ambiente build, DLL stub UnityEngine |
| v2.0.9200 | — | Migração .NET Framework 4.8 |
| v1.x | — | Versão original FluffyFish |

---

## Requisitos de Build

| Requisito | Versão | Notas |
|---|---|---|
| Visual Studio | 2022 | |
| .NET Framework SDK | 4.8 | Para projetos ModAPI |
| .NET Framework SDK | 3.5 | Apenas para BaseModLib |
| ModernWpf | 0.9.6 | NuGet |
| AsyncBridge | 0.3.1 | NuGet — em `libs/polyfills/` |
| TaskParallelLibrary | 1.0.2856 | NuGet — `System.Threading.dll` em `libs/polyfills/` |

---

## Licença

GNU General Public License v3.0 — segue a licença original.
