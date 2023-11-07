import { Component, OnInit } from '@angular/core';
import { UsuarioService } from './services/usuario.service';
import { Usuario } from './models/usuario';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  usuarioForm!: FormGroup;

  usuario: Usuario = {} as Usuario;
  usuarios: Usuario[] = [];
  escolaridades: { codigo: number; descricao: string }[] = [
    { codigo: 1, descricao: 'Infantil' },
    { codigo: 2, descricao: 'Fundamental' },
    { codigo: 3, descricao: 'Médio' },
    { codigo: 4, descricao: 'Superior' },
  ];

  constructor(
    private usuarioService: UsuarioService,
    private toastr: ToastrService,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    this.usuarioForm = this.fb.group({
      nome: [this.usuario.nome, Validators.required],
      sobrenome: [this.usuario.sobrenome, Validators.required],
      email: [this.usuario.email, [Validators.required, Validators.email]],
      dataNascimento: [this.usuario.dataNascimento, Validators.required],
      escolaridade: [this.usuario.escolaridade =1 ]
    });

    this.obterTodosUsuarios();
  }

  salvarUsuario() {
    if (this.usuario.id) {
      this.atualizarUsuario();
    } else {
      this.criarNovoUsuario();
    }
  }

  private atualizarUsuario() {
    this.usuarioService.atualizarUsuario(this.usuario).subscribe(
      () => {
        this.exibirToast('Usuário atualizado com sucesso!', 'success');
        this.limparForm();
      },
      (error) => {
        this.exibirToast(`${error}`, 'error');
      }
    );
  }

  private criarNovoUsuario() {
    this.usuarioService.criarUsuario(this.usuario).subscribe(
      () => {
        this.exibirToast('Usuário cadastrado com sucesso!', 'success');

        setTimeout(() => {
          this.limparForm();
        }, 1000);

      },
      (error) => {
        this.exibirToast(`${error}`, 'error');
      }
    );
  }

  obterTodosUsuarios() {
    this.usuarioService.obterTodosUsuarios().subscribe((obj) => {
      this.usuarios = obj;
    });
  }

  deletarUsuario(usuario: Usuario) {
    this.usuarioService.excluirUsuario(usuario).subscribe(() => {
      this.obterTodosUsuarios();
      this.exibirToast('Usuário excluído com sucesso!', 'success');
    });
  }

  editarUsuario(usuario: Usuario) {
    this.usuarioService.obterUsuario(usuario.id).subscribe((obj: Usuario) => {
      this.usuario = obj;
    });
  }

  limparForm() {
    this.usuarioForm.reset();
    this.usuario = {} as Usuario;
    this.obterTodosUsuarios();
  }


  obtemDescricaoEscolaridade(codigoEscolaridade: number): string {
    const escolaridade = this.escolaridades.find(
      (esc) => esc.codigo === codigoEscolaridade
    );
    return escolaridade ? escolaridade.descricao : 'Escolaridade Desconhecida';
  }

  exibirToast(mensagem: string, tipo: 'success' | 'error') {
    this.toastr.show(mensagem, '', {
      closeButton: true,
      timeOut: 3000,
      progressBar: true,
      positionClass: 'toast-top-right',
      enableHtml: true,
      tapToDismiss: true,
      toastClass: `ngx-toastr toast-${tipo}`,
    });
  }
}
