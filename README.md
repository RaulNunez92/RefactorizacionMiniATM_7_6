# Laboratorio 7.6 — Refactorización del Mini ATM (Clean Code & SRP)

Evolución del sistema Mini ATM aplicando principios de **Clean Code**, **Manejo Defensivo de Errores** y **Principio de Responsabilidad Única (SRP)** en C# (.NET 8).

---

## 📌 ENTREGABLE 1: Enlace al Repositorio Oficial
- **GitHub:** [https://github.com/RaulNunez92/RefactorizacionMiniATM_7_6](https://github.com/RaulNunez92/RefactorizacionMiniATM_7_6)

---

## 📐 ENTREGABLE 2: Arquitectura y Cambios Realizados

### 1. Desacoplamiento por Responsabilidad Única (SRP):
- **`CuentaBancaria`:** Encapsula las mutaciones del saldo con validaciones contables puras.
- **`ServicioATM`:** Capa de servicios que orquesta las transacciones financieras desacoplada de la consola.
- **`ConsolaATM`:** Controla la interfaz de usuario, captura con `decimal.TryParse` y optimiza las opciones del menú con el tipo `byte`.
- **`Program`:** Inicializador que inyecta las dependencias interactivamente.

### 2. Diagrama de Clases UML:
*(Ver archivo vectorial en `/docs/DiagramaClases_Lab7_6.pdf`)*

```
+---------------+       +---------------+       +----------------+
|  ConsolaATM   | ----> |  ServicioATM  | ----> | CuentaBancaria |
+---------------+       +---------------+       +----------------+
(Presentación / UI)    (Capa de Negocio)       (Modelo de Dominio)
```

---

## 📸 ENTREGABLE 3: Evidencias de Casos de Prueba (Normales y Excepcionales)

### 1. Escenario Normal: Depósito y Retiro Exitosos
![Prueba Normal](./docs/evidencia_operaciones_exitosas.png)

### 2. Escenario Excepcional: Intento de Sobregiro (Fondos Insuficientes)
![Fondos Insuficientes](./docs/evidencia_fondos_insuficientes.png)

### 3. Escenario Defensivo: Entrada No Numérica o Monto Negativo
![Entrada Inválida](./docs/evidencia_entrada_invalida.png)

---

## 📦 ENTREGABLE 4: Instrucciones de Compilación y Ejecución Independiente

```bash
# Ejecutar en modo desarrollo
dotnet run

# Publicar ejecutable independiente de consola:
dotnet publish -c Release -r win-x64 --self-contained false
```
*Binario generado en:* `bin/Release/net8.0/win-x64/publish/RefactorizacionMiniATM_7_6.exe`