# ECE369 Project B Multimedia GUI Application
ECE 369 -- Multimedia application with GUI for Project B.

This program is designed to send and receive .WAV files between two clients, and then be able to play/pause the .WAV file once the file has been received. Connection to clients is done by first publishing self to other clients on the network via UDP, and then connecting to available clients that have published themselves via TCP. .WAV file sending/receiving handled by TCP connection.

.WAV file sending/receiving network protocol is as defined:

1. Sending client requests TCP connection with receiving client.
2. Receiving client receives and automatically accepts connection. (Connections ALWAYS accepted by default.)
3. Sending client sends file.
4. Receiving client receives file, and closes connection when there is no data left to be read from TCP stream.

The source code for this program is available under the MIT License.

Credit must be given to the following authors:

Christopher Parks (cparks13@live.com)
