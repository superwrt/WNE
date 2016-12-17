/*
 *  CertGen
 * Written by Terra Yang <terra@superwrt.com>.
 * Using mbedTLS-2.4 library.
 * License: GPLv2
 */

#if !defined(MBEDTLS_CONFIG_FILE)
#include "mbedtls/config.h"
#else
#include MBEDTLS_CONFIG_FILE
#endif

#if defined(MBEDTLS_PLATFORM_C)
#include "mbedtls/platform.h"
#else
#include <stdio.h>
#define mbedtls_printf     printf
#endif

#if defined(MBEDTLS_BIGNUM_C) && defined(MBEDTLS_ENTROPY_C) && \
    defined(MBEDTLS_RSA_C) && defined(MBEDTLS_GENPRIME) && \
    defined(MBEDTLS_FS_IO) && defined(MBEDTLS_CTR_DRBG_C)
#include "mbedtls/x509_crt.h"
#include "mbedtls/x509_csr.h"
#include "mbedtls/entropy.h"
#include "mbedtls/ctr_drbg.h"
#include "mbedtls/bignum.h"
#include "mbedtls/x509.h"
#include "mbedtls/rsa.h"

#include <stdio.h>
#include <string.h>

#define KEY_PRIV "key.pem"
#define KEY_PUB  "key_pub.pem"
#define KEY_CERT "cert.pem"

#define KEY_SIZE 2048
#define EXPONENT 65537

#define DFL_NOT_BEFORE          "20010101000000"
#define DFL_NOT_AFTER           "20301231235959"

static int write_public_key(mbedtls_pk_context *key, const char *output_file)
{
	int ret;
	FILE *f;
	unsigned char output_buf[16000];
	unsigned char *c = output_buf;
	size_t len = 0;

	memset(output_buf, 0, 16000);

	if ((ret = mbedtls_pk_write_pubkey_pem(key, output_buf, 16000)) != 0)
		return(ret);

	len = strlen((char *)output_buf);


	if ((f = fopen(output_file, "wb")) == NULL)
		return(-1);

	if (fwrite(c, 1, len, f) != len)
	{
		fclose(f);
		return(-1);
	}

	fclose(f);

	return(0);
}
static int write_private_key(mbedtls_pk_context *key, const char *output_file)
{
	int ret;
	FILE *f;
	unsigned char output_buf[16000];
	unsigned char *c = output_buf;
	size_t len = 0;

	memset(output_buf, 0, 16000);

	if ((ret = mbedtls_pk_write_key_pem(key, output_buf, 16000)) != 0)
		return(ret);

	len = strlen((char *)output_buf);


	if ((f = fopen(output_file, "wb")) == NULL)
		return(-1);

	if (fwrite(c, 1, len, f) != len)
	{
		fclose(f);
		return(-1);
	}

	fclose(f);

	return(0);
}

int write_certificate(mbedtls_x509write_cert *crt, const char *output_file,
	int(*f_rng)(void *, unsigned char *, size_t),
	void *p_rng)
{
	int ret;
	FILE *f;
	unsigned char output_buf[4096];
	size_t len = 0;

	memset(output_buf, 0, 4096);
	if ((ret = mbedtls_x509write_crt_pem(crt, output_buf, 4096, f_rng, p_rng)) < 0)
		return(ret);

	len = strlen((char *)output_buf);

	if ((f = fopen(output_file, "w")) == NULL)
		return(-1);

	if (fwrite(output_buf, 1, len, f) != len)
	{
		fclose(f);
		return(-1);
	}

	fclose(f);

	return(0);
}

int main(int argc, char* argv[])
{
	int ret;
	mbedtls_pk_context key;
	//mbedtls_rsa_context rsa;
	mbedtls_entropy_context entropy;
	mbedtls_ctr_drbg_context ctr_drbg;
	mbedtls_x509write_cert crt;
	mbedtls_mpi serial;
	FILE *fpub = NULL;
	FILE *fpriv = NULL;
	const char *pers = "rsa_genkey";

	mbedtls_pk_init(&key);
	mbedtls_ctr_drbg_init(&ctr_drbg);

	mbedtls_printf("\n  . Seeding the random number generator...");
	fflush(stdout);

	mbedtls_entropy_init(&entropy);
	if ((ret = mbedtls_ctr_drbg_seed(&ctr_drbg, mbedtls_entropy_func, &entropy,
		(const unsigned char *)pers,
		strlen(pers))) != 0)
	{
		mbedtls_printf(" failed\n  ! mbedtls_ctr_drbg_seed returned %d\n", ret);
		goto exit;
	}

	mbedtls_printf(" ok\n  . Generating the RSA key [ %d-bit ]...", KEY_SIZE);
	fflush(stdout);

	//mbedtls_rsa_init(mbedtls_pk_rsa(key)/*&rsa*/, MBEDTLS_RSA_PKCS_V15, 0 );

	if ((ret = mbedtls_pk_setup(&key, mbedtls_pk_info_from_type(MBEDTLS_PK_RSA))) != 0)
	{
		mbedtls_printf(" failed\n  !  mbedtls_pk_setup returned -0x%04x", -ret);
		goto exit;
	}

	if ((ret = mbedtls_rsa_gen_key(mbedtls_pk_rsa(key)/*&rsa*/, mbedtls_ctr_drbg_random, &ctr_drbg, KEY_SIZE,
		EXPONENT)) != 0)
	{
		mbedtls_printf(" failed\n  ! mbedtls_rsa_gen_key returned %d\n\n", ret);
		goto exit;
	}

	mbedtls_printf(" ok\n  . Write key files...");
	if ((ret = write_private_key(&key, KEY_PRIV)) != 0)
	{
		mbedtls_printf(" failed\n");
		goto exit;
	}

	if ((ret = write_public_key(&key, KEY_PUB)) != 0)
	{
		mbedtls_printf(" failed\n");
		goto exit;
	}

	mbedtls_printf(" ok\n  . Write Cert file...");

	mbedtls_x509write_crt_init(&crt);
	mbedtls_x509write_crt_set_md_alg(&crt, MBEDTLS_MD_SHA256);
	mbedtls_mpi_init(&serial);

	mbedtls_x509write_crt_set_subject_key(&crt, &key);

	mbedtls_x509write_crt_set_issuer_key(&crt, &key);
	mbedtls_x509write_crt_set_issuer_name(&crt, "CN=CA,O=SuperWRT,C=WNE");
	mbedtls_x509write_crt_set_basic_constraints(&crt, 0, -1);

	mbedtls_x509write_crt_set_subject_name(&crt, "CN=Cert,O=SuperWRT,C=WNE");

	mbedtls_mpi_read_string(&serial, 10, "1");
	mbedtls_x509write_crt_set_serial(&crt, &serial);

	mbedtls_x509write_crt_set_validity(&crt, DFL_NOT_BEFORE, DFL_NOT_AFTER);

	mbedtls_x509write_crt_set_ns_cert_type(&crt,
		MBEDTLS_X509_NS_CERT_TYPE_SSL_SERVER);

	if ((ret = write_certificate(&crt, KEY_CERT,
		mbedtls_ctr_drbg_random, &ctr_drbg)) != 0)
	{
		char buf[1024];
		mbedtls_strerror(ret, buf, 1024);
		mbedtls_printf(" failed\n  !  write_certifcate -0x%02x - %s\n\n", -ret, buf);
		goto exit;
	}

	mbedtls_printf(" ok\n\n");

exit:

	if (fpub != NULL)
		fclose(fpub);

	if (fpriv != NULL)
		fclose(fpriv);

	mbedtls_rsa_free(mbedtls_pk_rsa(key)/*&rsa*/);
	mbedtls_ctr_drbg_free(&ctr_drbg);
	mbedtls_entropy_free(&entropy);

#if defined(_WIN32)
	if (argc == 1) {
		mbedtls_printf("  Press Enter to exit this program.\n");
		fflush(stdout); getchar();
	}
#endif

	return(ret);
}
#else
#error "Config error!"
#endif