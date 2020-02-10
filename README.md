# C# - WPF - Encyption and Decryption Connection String in Runtime with Visual Studio Installer Projects. [Year of Development: 2018]

About the application technologies and operation:

### Technologies:
- Programming Language: C#
- FrontEnd Side: Windows Presentation Foundation (WPF) - .NET Framework 4.6.1
- BackEnd Side: .NET Framework 4.6.1.
- Other used modul:
    - Visual Studio Installer Projects.

### Installation/ Configuration:

1. Restore necessary Packages on the selected project, run the following command in **PM Console**

   ```
   Update-Package -reinstall
   ```
     
### About the application:

In this application, I am going to show how to Encrypted Connection String when you Install your project with Visual Studio Projects and ho to Decrypted Connection String when you start the application on your computer.
 
#### Steps
- Configuration Data Protection Provider.
- Implement Visual Studio Installer Projects.
- Configurate Encryption Method in Installer Class.

### Useful Highlights:

**1. The following code to the App.config.config file of the data protection provider for the connectionString just under <configuration>**
 
  ```XML
  <connectionStrings configProtectionProvider="DataProtectionConfigurationProvider">
    <EncryptedData>
      <CipherData>
        <CipherValue>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAyabPvuLesE+fHSrMeSjz0gQAAAACAAAAAAADZgAAwAAAABAAAAC8JDy9QBfhSRy09ao0c1rOAAAAAASAAACgAAAAEAAAACUs8KSCMHfQZfEaGtmefBMwAAAA/FE3BhMYFaUMhsg2ipmg4RfRq0QArZmU3xazj0ouHCWsvVBLnfBesNrARD9znB9wFAAAAGn3/E4J+zYKFk28lHMBffpBCzKr</CipherValue>
      </CipherData>
    </EncryptedData>
  </connectionStrings>
  ```

**2. The following code to the App.config file of the machine use Data Protection Provider (DPAPI) for the application just under <configuration>**

   ```XML
  <configProtectedData>
    <providers>
      <add useMachineProtection="true"
           name="DPAPIProtection"
           type="System.Configuration.DpapiProtectedConfigurationProvider,System.Configuration, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" />
    </providers>
  </configProtectedData>
  ```
