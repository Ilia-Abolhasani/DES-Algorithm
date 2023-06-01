# DES Encryption Algorithm

This repository contains an implementation of the DES (Data Encryption Standard) encryption algorithm written in C#. DES is a symmetric encryption algorithm widely used for securing sensitive data.

## Description

The DES Encryption Algorithm repository provides an implementation of the DES algorithm for encrypting and decrypting data. The algorithm follows the standard DES specifications.

## Bug in Decipher Phase

There is currently a known bug in the decipher phase of the implementation. When decrypting data, the algorithm produces incorrect results under certain conditions. Please be aware of this bug when using the decipher functionality.

## Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/Ilia-Abolhasani/data-encryption-standard.git
2. Open the project in your preferred IDE (Integrated Development Environment).

3. Build the project to ensure all dependencies are resolved.

## Usage

To use the DES Encryption Algorithm, follow these steps:

1. Run the application from your IDE or build an executable file.

2. Use the provided user interface to enter the message you want to encrypt.

3. Select the appropriate encryption key or enter a custom key in the provided combobox.

4. Click the "Encrypt" button to encrypt the message using the selected key.

5. The encrypted message will be displayed in the output area.

6. To decrypt the message, select the corresponding key from the combobox or enter a custom key.

7. Click the "Decrypt" button to decrypt the encrypted message.

8. The decrypted message will be displayed in the output area.

9. Customize the encryption settings and algorithm parameters as needed for your specific use case.

10. Ensure proper handling and storage of encryption keys to maintain data security.

11. Review the provided documentation and code comments for more information on using the DES Encryption Algorithm.

## Contributing

Contributions are welcome! If you would like to contribute to this project, please follow these steps:

1. Fork the repository.

2. Create a new branch for your feature or bug fix.

3. Make your changes and commit them with descriptive messages.

4. Push your changes to your forked repository.

5. Submit a pull request explaining your changes.

Please ensure that your contributions align with the coding standards and guidelines followed in this project. Also, make sure to test your changes thoroughly before submitting a pull request.

## License

This project is licensed under the [MIT License](LICENSE).
