**NOTE: This is a work in progress! There isn't yet an easy way to load compiled binaries into the Shaderception VM. I'm working on it.**

# shaderception-standalone

Run [Shaderception](https://github.com/pema99/Shaderception) compiler outside of unity.

Setup:
- Install dotnet core
- Clone repo
- `git submodule update --init --recursive`
- `dotnet run <file to compile>`

Will return 2 files, a `.bin` and `.asm`. `.bin` is the compiled binary, `.asm` is the binary in mnemonic (readable) format.
